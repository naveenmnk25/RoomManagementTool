If(Object_Id('AmountDetails') Is Not Null)
Begin
	Drop Table [AmountDetails]
End
GO

Create Table DBO.[AmountDetails]
(
	 Id					Int  Identity(1, 1)	Not Null
	,RoomRentAmount		Int
	,FootAmountAmount	Int
	,DetectedAmt		Int
	,CreatedBy			Int
	,CreatedDate		DateTime
	,ModifiedDate		DateTime
	,ModifiedBy			Int
)
GO

Alter Table dbo.AmountDetails
Add Constraint PK_AmountDetails Primary Key (Id)

Alter Table dbo.AmountDetails
Add Constraint DF_AmountDetails_CreatedDate
Default GetDate() FOR CreatedDate
Go

Alter Table dbo.AmountDetails
Add Constraint DF_AmountDetails_ModifiedDate
Default GetDate() FOR ModifiedDate
Go
