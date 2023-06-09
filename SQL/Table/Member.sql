If(Object_Id('Member') Is Not Null)
Begin
	Drop Table [Member]
End
GO

Create Table DBO.[Member]
(
	 Id					Int  Identity(1, 1)	Not Null
	,[Name]				Nvarchar(100)		
	,Company			Nvarchar(100)		
	,isVecate			bit		
	,isFood				bit		
	,[JoinDate]			DateTime		
	,[VecateDate]		DateTime		
	,CreatedBy			Int
	,CreatedDate		DateTime
	,ModifiedDate		DateTime
	,ModifiedBy			Int
)
GO

Alter Table dbo.Member
Add Constraint PK_Member Primary Key (Id)

Alter Table dbo.Member
Add Constraint DF_Member_CreatedDate
Default GetDate() FOR CreatedDate
Go

Alter Table dbo.Member
Add Constraint DF_Member_ModifiedDate
Default GetDate() FOR ModifiedDate
Go

Alter Table dbo.Member
Add Constraint DF_Member_ModifiedDate
Default GetDate() FOR ModifiedDate
Go

Alter Table dbo.Member
Add Constraint DF_Member_isVecate
Default 0 FOR isVecate
Go

Alter Table dbo.Member
Add Constraint DF_Member_isFood
Default 0 FOR isFood
Go

