Create Procedure GetAdvance

As
Begin

	Select 
	(
		Select Name = m.Name
			,Memberid = m.Id
			,AdvanceCalId = Ac.Id
			,AmountGiven = Ac.AmountGiven
			,AmountReFund = Ac.AmountReFund
			,RemAmtFromAd = Ac.RemAmtFromAd
			,DetectedAmt  = Ad.DetectedAmt
		From Member(Nolock) m
		Left Join AdvanceCal(Nolock) Ac
			On m.Id = Ac.MemberId
		, AmountDetails(Nolock) Ad
			
		For Json Path
	) As JsonResult

End


