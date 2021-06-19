uses System;

begin
  //write(not s.EndsWith(s[s.Length-1]+s[s.Length-1]+s[s.Length]));                           
  //WriteAllLines('names.dat', ReadAllLines('names.dat', Encoding.UTF8).ConvertAll(x -> x.ToWords()).Where(x -> x[0][1].IsUpper).Select(x -> x.JoinToString).ToArray(), Encoding.UTF8);
  var names := ReadAllLines('names.dat', Encoding.UTF8).ConvertAll(x -> x.ToWords()[0]);
  WriteAllLines('surnames.dat', ReadAllLines('surnames.dat', Encoding.UTF8).ConvertAll(x ->
  begin
    var tw := x.ToWords(); result := new ValueTuple<string, integer>(tw[0], tw[1].ToInteger())
  end).Where(x -> not names.Contains(x.Item1)).Select(x -> x.Item1 + ' ' + x.Item2).ToArray(), Encoding.UTF8);
end.