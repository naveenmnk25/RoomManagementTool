If(Object_Id('AdvanceCal') Is Not Null)
Begin
	Drop Table [AdvanceCal]
End
GO

Create Table DBO.[AdvanceCal]
(
	 Id					Int  Identity(1, 1)	Not Null
	,[MemberId]			Int		
	,AmountGiven		Int
	,AmountReFund		Int
	,RemAmtFromAd		Int
	,DetectedAmt		Int
	,[Date]				DateTime		
	,CreatedBy			Int
	,CreatedDate		DateTime
	,ModifiedDate		DateTime
	,ModifiedBy			Int
)
GO

Alter Table dbo.AdvanceCal
Add Constraint PK_AdvanceCal Primary Key (Id)

Alter Table dbo.AdvanceCal
Add Constraint DF_AdvanceCal_CreatedDate
Default GetDate() FOR CreatedDate
Go

Alter Table dbo.AdvanceCal
Add Constraint DF_AdvanceCal_ModifiedDate
Default GetDate() FOR ModifiedDate
Go