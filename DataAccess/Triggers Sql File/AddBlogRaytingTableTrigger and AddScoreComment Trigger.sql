--Create Trigger AddBlogRaytingTable
--on Blogs 
--After Insert
--As
--Declare @ID int
--Select @ID=Id from inserted
--Insert into BlogRaytings(BlogId,BlogTotalScore,BlogRaytingCount)
--Values(@ID,0,0)

Create Trigger AddScoreComment 
On Comments
After Insert 
As
Declare @ID int
Declare @Score int
Declare @RaytingCount int
Select @ID=BlogId,@Score=Score from inserted
Update BlogRaytings Set BlogTotalScore=BlogTotalScore+@Score,BlogRaytingCount+=1
Where Id=@ID