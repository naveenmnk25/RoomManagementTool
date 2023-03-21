Alter Procedure GetFootetails

As
Begin

	Select 
	(
		Select Name = m.Name
			, Memberid = m.Id
			, FoodDetailsid = fd.Id
			,AmountToGive = Ad.FootAmountAmount
			,AmountRecived = CASE When fd.AmountRecived = 0 Then 0 Else fd.AmountRecived End 
			,RemainingTogive = Ad.FootAmountAmount - CASE When fd.AmountRecived >0 Then fd.AmountRecived Else 0 End
		From Member(Nolock) m
		Left Join FoodDetails(Nolock) fd
			On m.Id = fd.MemberId
		, AmountDetails(Nolock) Ad
	     where m.isFood = 1
			
		For Json Path
	) As JsonResult

End