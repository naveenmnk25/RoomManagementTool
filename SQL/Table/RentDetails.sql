If(Object_Id('RentDetails') Is Not Null)
Begin
	Drop Table [RentDetails]
End
GO

Create Table DBO.[RentDetails]
(
	 Id					Int  Identity(1, 1)	Not Null
	,[MemberId]			Int		
	--,[Name]				Nvarchar(100)		
	,AmountToGive		Int
	,AmountRecived		Int
	,CreatedBy			Int
	,CreatedDate		DateTime
	,ModifiedDate		DateTime
	,ModifiedBy			Int
)
GO

Alter Table dbo.RentDetails
Add Constraint PK_RentDetails Primary Key (Id)

Alter Table dbo.RentDetails
Add Constraint DF_RentDetails_CreatedDate
Default GetDate() FOR CreatedDate
Go

Alter Table dbo.RentDetails
Add Constraint DF_RentDetails_ModifiedDate
Default GetDate() FOR ModifiedDate
Go