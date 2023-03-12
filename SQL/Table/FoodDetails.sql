If(Object_Id('FoodDetails') Is Not Null)
Begin
	Drop Table [FoodDetails]
End
GO

Create Table DBO.[FoodDetails]
(
	 Id					Int  Identity(1, 1)	Not Null
	,[MemberId]			Int		
	,AmountToGive		Int
	,AmountRecived		Int
	,CreatedBy			Int
	,CreatedDate		DateTime
	,ModifiedDate		DateTime
	,ModifiedBy			Int
)
GO

Alter Table dbo.FoodDetails
Add Constraint PK_FoodDetails Primary Key (Id)

Alter Table dbo.FoodDetails
Add Constraint DF_FoodDetails_CreatedDate
Default GetDate() FOR CreatedDate
Go

Alter Table dbo.FoodDetails
Add Constraint DF_FoodDetails_ModifiedDate
Default GetDate() FOR ModifiedDate
Go