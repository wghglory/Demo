select * from Aspx_news

insert into Aspx_News values(@title,@content,@date,@author,@bigImg,@smallImg,@typeId)

select * from Aspx_news

--����ÿҳ5�����鿴��3ҳ
alter proc usp_getNewsByPage
@pagesize int, --ÿҳ�ļ�¼����
@pageIndex int,--��ǰҪ�鿴�ڼ�ҳ
@recordCount int output,--�����ܹ��ļ�¼����
@pagecount int output --һ�����Էֶ���ҳ
as
--1.Ҫ��ѯ������ͨ�������ҵ���Ȼ����ҵ������ݷ��뵽��ʱ����
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
--2.�ٶ������������������Ӳ�ѯ
----���������ѯ��ǰҪ��ʾ��ҳ�ļ�¼������
select * from 
(select *,rn=row_number() over(order by NewsIssueDate desc) from #NewsTemp) as t
where t.rn between ((@pageIndex-1)*@pagesize)+1 and (@pageIndex*@pagesize)
--�ѱ����ܼ�¼������ѯ����
select @recordCount=count(*) from #NewsTemp
--�����ܼ�¼����,����һ���ж���ҳ
set @pageCount=ceiling(@recordCount*1.0/@pagesize)





select * from #NewsTemp


----���������ѯ��ǰҪ��ʾ��ҳ�ļ�¼������
--select * from 
--(select *,rn=row_number() over(order by NewsIssueDate desc) from Aspx_news) as t
--where t.rn between ((@pageIndex-1)*@pagesize)+1 and (@pageIndex*@pagesize)
----�ѱ����ܼ�¼������ѯ����
--select @recordCount=count(*) from Aspx_news
----�����ܼ�¼����,����һ���ж���ҳ
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
	









