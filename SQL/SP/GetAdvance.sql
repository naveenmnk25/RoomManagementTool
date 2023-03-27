ALTER Procedure [dbo].[GetAdvance]

As
Begin

	--DECLARE @AjithDetuctAmt  Int;
	--SELECT @TestVariable = 100;

	;With ajtamt As
	(
		Select  m.Id,m.Name ,
		RemAmtFromAd= case When AmountGiven = 0 Then ((Ad.DetectedAmt / 7)/DATEDIFF(Month, '2022/06/25', GETDATE()))* DATEDIFF(Month, m.JoinDate, m.VecateDate)
							   When (Ac.AmountGiven - Ac.AmountReFund) = 0 Then 0
			  Else ((Ad.DetectedAmt / 7)/DATEDIFF(Month, '2022/06/25', GETDATE()))* DATEDIFF(Month, m.JoinDate, m.VecateDate) End
		from Member m
		Left Join AdvanceCal(Nolock) Ac
			On m.Id = Ac.MemberId
		,AmountDetails(Nolock) Ad
		where m.Id in (5,10)
	),
	detectedAdvAmt as
	(
	  select m.Id, DetectedAdvAmt1 = Case 
							   When m.id = 5 then ((select RemAmtFromAd from ajtamt	where Id =5 )-  (select  RemAmtFromAd from ajtamt	where Id =10))
							   When AmountGiven = 0 Then ((Ad.DetectedAmt / 7)/DATEDIFF(Month, '2022/06/25', GETDATE()))* DATEDIFF(Month, m.JoinDate, m.VecateDate)
							   When (Ac.AmountGiven - Ac.AmountReFund) = 0 Then 0
			  Else ((Ad.DetectedAmt / 7)/DATEDIFF(Month, '2022/06/25', GETDATE()))* DATEDIFF(Month, m.JoinDate, m.VecateDate) End
		From Member(Nolock) m
		Left Join AdvanceCal(Nolock) Ac
			On m.Id = Ac.MemberId
		,AmountDetails(Nolock) Ad 
	)
	--select name , RemAmtFromAd from ajtamt,
	--select Id , DetectedAdvAmt1 from detectedAdvAmt
	 --DECLARE @AjithDetuctAmt as Int =  (select RemAmtFromAd from ajtamt	where Id =5 )-  (select  RemAmtFromAd from ajtamt	where Id =10)
	  
	Select 
	(
		Select Name = m.Name
			,Memberid = m.Id
			,AdvanceCalId = Ac.Id
			,AmountGiven = Ac.AmountGiven
			,AmountReFund = Ac.AmountReFund
			,DetectedAmt  = Ac.DetectedAmt 
			,DetectedAdvAmt  = (select DetectedAdvAmt1 from detectedAdvAmt where m.Id = Id)
			,RemAmtFromAd = case 
						when (Ac.AmountGiven - Ac.AmountReFund - (Ad.DetectedAmt / 7)) <= 0 Then 0 
						When (m.Id =10) Then ((Ac.AmountGiven - (select DetectedAdvAmt1 from detectedAdvAmt where m.Id = Id)-Ac.AmountReFund)-(Select DetectedAdvAmt1 from detectedAdvAmt where Id =5))
						Else (Ac.AmountGiven - (select DetectedAdvAmt1 from detectedAdvAmt where m.Id = Id)-Ac.AmountReFund) End
			,IsVecate = m.IsVecate
			,MonthStayed =  DATEDIFF(Month, m.JoinDate, m.VecateDate)/1
			,m.JoinDate as JoinDate
			,m.VecateDate as VecateDate
		From Member(Nolock) m
		Left Join AdvanceCal(Nolock) Ac
			On m.Id = Ac.MemberId
		,AmountDetails(Nolock) Ad
		For Json Path
	) As JsonResult

End

