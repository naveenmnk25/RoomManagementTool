ALTER Procedure [dbo].[GetAdvance]

As
Begin

	Select 
	(
		Select Name = m.Name
			,Memberid = m.Id
			,AdvanceCalId = Ac.Id
			,AmountGiven = Ac.AmountGiven
			,AmountReFund = Ac.AmountReFund
			,RemAmtFromAd = case when (Ac.AmountGiven - Ac.AmountReFund - (Ad.DetectedAmt / 7)) <= 0 Then 0 Else (Ac.AmountGiven - Ac.AmountReFund - (Ad.DetectedAmt / 8)) End
			,DetectedAmt  = Ac.DetectedAmt 
			,DetectedAdvAmt  = 
			Case When AmountGiven = 0 Then ((Ad.DetectedAmt / 7)/DATEDIFF(Month, '2022/06/25', GETDATE()))* DATEDIFF(Month, m.JoinDate, m.VecateDate)
				When (Ac.AmountGiven - Ac.AmountReFund) = 0 Then 0
			  Else ((Ad.DetectedAmt / 7)/DATEDIFF(Month, '2022/06/25', GETDATE()))* DATEDIFF(Month, m.JoinDate, m.VecateDate) End
			,IsVecate = m.IsVecate
		From Member(Nolock) m
		Left Join AdvanceCal(Nolock) Ac
			On m.Id = Ac.MemberId
		, AmountDetails(Nolock) Ad
			
		For Json Path
	) As JsonResult

End

