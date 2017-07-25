create view V_AtacLog_GroupIp
as
select Ip, min(RequestDate) RequestDate, count(*) Numar
from AtacLog
group by Ip