use Observations
Select top(100)
  UserName, LastActivityDate
from
  aspnet_Users
order by
  LastActivityDate Desc