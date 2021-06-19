{$reference 'System.Windows.Forms.dll'}
uses System.Windows.Forms;

function genlaw(s: string): string;
begin
  var sb := new StringBuilder();
  var underlvl := $'_{s.Where(x -> char.IsUpper(x)).JoinToString().ToLower}l';
  sb.AppendLine($'        #region {s}Law');
  sb.AppendLine($'        public enum {s}Law');
  sb.AppendLine( '        {');
  sb.AppendLine($'            All,');
  sb.AppendLine( '        }');
  sb.AppendLine();
  sb.AppendLine($'        public const {s}Law Default{s}RandomLaw = {s}Law.All;');
  sb.AppendLine($'        static Dictionary<{s}Law, RandomationLaw<{s}>.PercentLaw> {s.ToLower}law = new Dictionary<{s}Law, RandomationLaw<{s}>.PercentLaw>();');
  sb.AppendLine($'        private static {s}Law {underlvl} = Default{s}RandomLaw;');
  sb.AppendLine($'        public static {s}Law Current{s}RandomLaw');
  sb.AppendLine( '        {');
  sb.AppendLine($'            get => {underlvl};');
  sb.AppendLine($'            set => {underlvl} = value;');
  sb.AppendLine( '        }');
  sb.AppendLine($'        internal static Enum RandomLaw_{s}(Random rnd) => {s.ToLower}law[{underlvl}].Get(rnd.NextDouble());');
  sb.AppendLine($'        #endregion');
  
  Result := sb.ToString();
end;

function genxml(s: string): string;
begin
  var sb := new StringBuilder();
  sb.AppendLine($'  <{s}RandomLaws>');
  sb.AppendLine($'    <{s}RandomLaw law="All">');
  sb.AppendLine($'      <{s}Percent chance="0.1" value="Child"/>');
  sb.AppendLine($'    </{s}RandomLaw>');
  sb.AppendLine($'  </{s}RandomLaws>');
  
  Result := sb.ToString();
end;

function genxmlread(s: string): string;
begin
  var sb := new StringBuilder();
  sb.AppendLine($'                    case "{s}RandomLaws":');
  sb.AppendLine( '                      {');
  sb.AppendLine($'                          foreach (XmlElement rndlaw in rndlaws)');
  sb.AppendLine( '                          {');
  sb.AppendLine($'                              var value = rndlaw.GetAttribute("law").ToEnum<{s}Law>();');
  sb.AppendLine($'                              var x = new RandomationLaw<{s}>.PercentLaw();');
  sb.AppendLine($'                              foreach (XmlElement val in rndlaw)');
  sb.AppendLine( '                              {');
  sb.AppendLine($'                                  x.Add((val.GetAttribute("chance").ToDouble(), val.GetAttribute("value").ToEnum<{s}>()));');
  sb.AppendLine( '                              }');
  sb.AppendLine($'                              x.Init();');
  sb.AppendLine($'                              {s.ToLower}law.Add(value, x);');
  sb.AppendLine( '                          }');
  sb.AppendLine( '                      }');
  sb.AppendLine($'                      break;');
  
  Result := sb.ToString();
end;

begin
  var s := 'EyesColor';
  Println('Defaults.cs {class Defaults}:');
  Println('----------------------------------------------------------------');
  Println(genlaw(s));
  Println('----------------------------------------------------------------');
  Println('Defaults.cs {void ReadXmlFile}:');
  Println('----------------------------------------------------------------');
  Println(genxmlread(s));
  Println('----------------------------------------------------------------');
  Println('Defaultx.xml:');
  Println('----------------------------------------------------------------');
  Println(genxml(s));
  Println('----------------------------------------------------------------');
  Println('RandomationLaw.cs {RandomationLawHelper}:');
  Println('----------------------------------------------------------------');
  Println($'add(CachedEnum<Archetypes.{s}>.Type, Defaults.RandomLaw_{s});');
  Println('----------------------------------------------------------------');
end.