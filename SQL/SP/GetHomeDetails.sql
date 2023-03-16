If(Object_Id('GetHomeDetails') Is Not Null)
Begin
	Drop Procedure GetHomeDetails
End
GO

Create Procedure GetHomeDetails

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
			
		For Json Path
	) As JsonResult

End