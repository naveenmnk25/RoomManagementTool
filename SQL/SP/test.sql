 declare @sesion int = 1; --1 and 2
 declare @SectionId int = 1; --1 and 2

;With ExceptAmt As
		(
			select  ex.MemberId , case when (sum(ex.Price)) = null then 0 else  sum(ex.Price) End as Tamt
				From Expance(Nolock) ex
				--where SectionId = @SectionId
				group by ex.MemberId
		)
		,totalfoodamt as
		(
			Select  Sum(AmountRecived) as TAmountRecived
			From FoodDetails where SectionId =1
		),oldamt as
		(
			select  Memberid = m.Id ,
			AmountToGive = case when m.Id = 6  then 1500 else Ad.FootAmountAmount end
			,RemainingTogive1 = (CASE when m.Id = 6 then 1500 else Ad.FootAmountAmount end) - (CASE When fd.AmountRecived >0 Then fd.AmountRecived   Else 0 End)
			,AmountRecived = CASE When fd.AmountRecived = 0 Then 0 Else fd.AmountRecived End 
			,ExceptAmt1 = case when (Case When m.Id = 1 Then (Select Tamt From ExceptAmt where m.Id = MemberId )-(Select TAmountRecived From totalfoodamt where SectionId =1)Else (Select Tamt From ExceptAmt where m.Id = MemberId) End) = null then 0 else (Case When m.Id = 1 Then (Select Tamt From ExceptAmt where m.Id = MemberId and SectionId = 1)-(Select TAmountRecived From totalfoodamt where SectionId =1)Else (Select Tamt From ExceptAmt where m.Id = MemberId) End) end
			From Member(Nolock) m
		Left Join FoodDetails(Nolock) fd
			On m.Id = fd.MemberId
		, AmountDetails(Nolock) Ad
	     where m.isFood = 1  and fd.SectionId =1  and  Ad.Id = 1
		),secondtable as
		(
			Select   Name = m.Name
			, Memberid = m.Id
			, FoodDetailsid = case when  Ad.Id = 1 then fd.Id when fd.Id != null then fd.Id   When Ad.Id = 2 then null else  null end
			,AmountToGive = case when m.Id = 6  then 1500 else Ad.FootAmountAmount end
			,AmountRecived = CASE When fd.AmountRecived = 0 Then 0 Else fd.AmountRecived End 
		
			,RemainingTogive = case when m.Id = 3 then ((((CASE when m.Id = 6 then 1500 else Ad.FootAmountAmount end)  - (CASE When fd.AmountRecived >0 Then fd.AmountRecived   Else 0 End))  - Case When (select  o.ExceptAmt1 from oldamt o where o.Memberid = m.Id) = null then 0 Else (select  o.ExceptAmt1 from oldamt o where o.Memberid = m.Id)End) + (Select o.RemainingTogive1 from oldamt o where o.Memberid = m.Id))
			else 
			((CASE when m.Id = 6 then 1500 else Ad.FootAmountAmount end)  - (CASE When fd.AmountRecived >0 Then fd.AmountRecived   Else 0 End))  - Case When (select  o.ExceptAmt1 from oldamt o where o.Memberid = m.Id) = null then 0 Else (select  o.ExceptAmt1 from oldamt o where o.Memberid = m.Id)End  End
			,ExceptAmt = Case When m.Id = 1 Then (Select Tamt From ExceptAmt where m.Id = MemberId and SectionId = @SectionId)-(Select TAmountRecived From totalfoodamt where SectionId =@SectionId)Else (Select Tamt From ExceptAmt where m.Id = MemberId and SectionId = @SectionId) End
		From Member(Nolock) m
		Left Join FoodDetails(Nolock) fd
			On m.Id = fd.MemberId
		, AmountDetails(Nolock) Ad
	     where m.isFood = 1  and fd.SectionId =@SectionId  and  Ad.Id = 3 and @sesion = 2
		),firsttable as
		(
					Select   Name = m.Name
			, Memberid = m.Id
			, FoodDetailsid = case when  Ad.Id = 1 then fd.Id when fd.Id != null then fd.Id   When Ad.Id = 2 then null else  null end
			,AmountToGive = case when m.Id = 6  then 1500 else Ad.FootAmountAmount end
			,AmountRecived = CASE When fd.AmountRecived = 0 Then 0 Else fd.AmountRecived End 
			,RemainingTogive = (CASE when m.Id = 6 then 1500 else Ad.FootAmountAmount end) - (CASE When fd.AmountRecived >0 Then fd.AmountRecived   Else 0 End)
			,ExceptAmt = Case When m.Id = 1 Then (Select Tamt From ExceptAmt where m.Id = MemberId and SectionId = @SectionId)-(Select TAmountRecived From totalfoodamt where SectionId =@SectionId)Else (Select Tamt From ExceptAmt where m.Id = MemberId) End
		From Member(Nolock) m
		Left Join FoodDetails(Nolock) fd
			On m.Id = fd.MemberId
		, AmountDetails(Nolock) Ad
	     where m.isFood = 1  and fd.SectionId =@SectionId  and  Ad.Id = 1 and @sesion = 1
		)
		--select * from oldamt;
			
			

--or fd.SectionId = null or fd.SectionId = 0
			Select IIF  ((@sesion = 1),(select * from firsttable ),(select * from secondtable ))
			
			--or fd.SectionId = null or fd.SectionId = 0


		

			
			


