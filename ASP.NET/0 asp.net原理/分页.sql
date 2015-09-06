select * from Aspx_news

insert into Aspx_News values(@title,@content,@date,@author,@bigImg,@smallImg,@typeId)

select * from Aspx_news

--假设每页5条，查看第3页
alter proc usp_getNewsByPage
@pagesize int, --每页的记录条数
@pageIndex int,--当前要查看第几页
@recordCount int output,--表中总共的记录条数
@pagecount int output --一共可以分多少页
as
--1.要查询的数据通过链接找到，然后把找到的数据放入到临时表中
select * into #NewsTemp from 
(select
	NewsId, 
	NewsTitle, 
	NewsIssueDate, 
	NewsAuthor, 
	NewsSmallImage,
	TypeName
from aspx_news n inner join aspx_type t
on n.newstypeid=t.typeId) as Tbl
--2.再对这个结果进行其他复杂查询
----根据需求查询当前要显示的页的记录的条数
select * from 
(select *,rn=row_number() over(order by NewsIssueDate desc) from #NewsTemp) as t
where t.rn between ((@pageIndex-1)*@pagesize)+1 and (@pageIndex*@pagesize)
--把表中总记录条数查询出来
select @recordCount=count(*) from #NewsTemp
--根据总记录条数,计算一共有多少页
set @pageCount=ceiling(@recordCount*1.0/@pagesize)





select * from #NewsTemp


----根据需求查询当前要显示的页的记录的条数
--select * from 
--(select *,rn=row_number() over(order by NewsIssueDate desc) from Aspx_news) as t
--where t.rn between ((@pageIndex-1)*@pagesize)+1 and (@pageIndex*@pagesize)
----把表中总记录条数查询出来
--select @recordCount=count(*) from Aspx_news
----根据总记录条数,计算一共有多少页
--set @pageCount=ceiling(@recordCount*1.0/@pagesize)

declare @rc int,@pc int
exec usp_getNewsByPage @pagesize=6,@pageIndex=7,@recordCount=@rc output,@pageCount=@pc output
print @rc
print @pc







print ceiling(100*1.0/3)


select * from aspx_news
select * from aspx_type
select * into #NewsTemp from 
(select
	NewsId, 
	NewsTitle, 
	NewsIssueDate, 
	NewsAuthor, 
	NewsSmallImage,
	TypeName
from aspx_news n inner join aspx_type t
on n.newstypeid=t.typeId) as Tbl
select * from #NewsTemp

select * from aspx_news
	









