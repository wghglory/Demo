select SId
	 , SName
	 , SAge
	 , SEmail
	 , SBirthday
	 , SGender
from
	T_Students
go
insert into T_Students (SName
					  , SAge
					  , SEmail
					  , SBirthday
					  , SGender)
values
	(@SName, @SAge, @SEmail, @SBirthday, @SGender)
go
update T_Students
set
	SName = @SName, SAge = @SAge, SEmail = @SEmail, SBirthday = @SBirthday, SGender = @SBirthday
where
	SId = @SId

go
delete T_Students
where
	SId = @SId


go


alter proc Usp_PageStudent
@pageIndex int,
@pageSize int
as 
begin
select *
into
	#TempStudent from
(
select [SId]
	  , SName
	  , SAge
	  , SEmail
	  , SBirthday
	  , SGender
	  , Rn = row_number() over (order by [SId] desc)
 from
	 T_Students) as tt


	 select [SId]
	  , SName
	  , SAge
	  , SEmail
	  , SBirthday
	  , SGender
	  from #TempStudent
where #TempStudent.Rn between
(@pageIndex-1)*@pageSize+1 and @pageIndex*@pageSize
end

go

select count([SId]) from T_Students
go

exec Usp_PageStudent @pageIndex=1,@pageSize=5

select SId, SName, SAge, SEmail, SBirthday, SGender from T_Students where SId=@sid