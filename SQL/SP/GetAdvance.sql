ALTER Procedure [dbo].[GetAdvance]

As
Begin

	--DECLARE @AjithDetuctAmt  Int;
	--SELECT @TestVariable = 100;

	;With ajtamt As
	(
		Select  m.Id,m.Name ,
		RemAmtFromAd=case when (Ac.AmountGiven - Ac.AmountReFund - (Ad.DetectedAmt / 7)) <= 0 Then 0 Else (Ac.AmountGiven - Ac.AmountReFund - (Ad.DetectedAmt / 8)) End
		from Member m
		Left Join AdvanceCal(Nolock) Ac
			On m.Id = Ac.MemberId
		,AmountDetails(Nolock) Ad
		where m.Id in (5,10)
	)
	 --DECLARE @AjithDetuctAmt as Int =  (select RemAmtFromAd from ajtamt	where Id =5 )-  (select  RemAmtFromAd from ajtamt	where Id =10)
	  
	Select 
	(
		Select Name = m.Name
			,Memberid = m.Id
			,AdvanceCalId = Ac.Id
			,AmountGiven = Ac.AmountGiven
			,AmountReFund = Ac.AmountReFund
			,RemAmtFromAd = case 
							when (Ac.AmountGiven - Ac.AmountReFund - (Ad.DetectedAmt / 7)) <= 0 Then 0 
							Else (Ac.AmountGiven - Ac.AmountReFund - (Ad.DetectedAmt / 8)) End
			,DetectedAmt  = Ac.DetectedAmt 
			,DetectedAdvAmt  = 
			Case 
				When m.id = 5 then ((select RemAmtFromAd from ajtamt	where Id =5 )-  (select  RemAmtFromAd from ajtamt	where Id =10))
				When AmountGiven = 0 Then ((Ad.DetectedAmt / 7)/DATEDIFF(Month, '2022/06/25', GETDATE()))* DATEDIFF(Month, m.JoinDate, m.VecateDate)
				When (Ac.AmountGiven - Ac.AmountReFund) = 0 Then 0
			  Else ((Ad.DetectedAmt / 7)/DATEDIFF(Month, '2022/06/25', GETDATE()))* DATEDIFF(Month, m.JoinDate, m.VecateDate) End
			,IsVecate = m.IsVecate
			,MonthStayed =  DATEDIFF(Month, m.JoinDate, m.VecateDate)/1
			--,AjithDetecteAmtNew = ((select RemAmtFromAd from ajtamt	where Id =5 )-  (select  RemAmtFromAd from ajtamt	where Id =10))
		From Member(Nolock) m
		Left Join AdvanceCal(Nolock) Ac
			On m.Id = Ac.MemberId
		,AmountDetails(Nolock) Ad
		For Json Path
	) As JsonResult

End

