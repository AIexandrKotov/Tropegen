using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tropegenbase.Characters;

namespace Tropegen
{
    public class CharacterFile
    {
        public bool Canceled { get; set; }
        public bool Edited { get; set; }
        public string Path { get; set; }
        public string Name { get; set; }
        private List<Character> characterlist;
        public List<Character> CharacterList 
        {
            get
            {
                Edited = true;
                return characterlist; 
            }
        }

        internal CharacterFile(string filename)
        {
            Path = filename;
            Name = System.IO.Path.GetFileNameWithoutExtension(filename);
        }

        public CharacterFile(string filename, Character[] characters) : this(filename)
        {
            characterlist = characters.ToList();
        }

        public void Rename(string newname)
        {
            if (File.Exists(Path))
            {
                Load();
                File.Delete(Path);
            }
            Path = Extended.GetPath() + newname + ".tgc";
            Name = newname;
            Save();
        }

        public void Remove()
        {
            if (File.Exists(Path)) File.Delete(Path);
        }

        public static CharacterFile New(string name)
        {
            var cf = new CharacterFile(Extended.GetPath() + name + ".tgc");
            cf.characterlist = new List<Character>();
            return cf;
        }

        public void Save()
        {
            Character.Save(Path, CharacterList);
        }

        public void Load()
        {
            Edited = false;
            try
            {
                characterlist = Character.Load(Path).ToList();
            }
            catch
            {
                Canceled = true;
                return;
            }
        }

        public static List<CharacterFile> CharacterFiles()
        {
            var filenames = Directory.GetFiles(Extended.GetPath(), "*.tgc");
            var ret = new List<CharacterFile>();
            for (var i = 0; i < filenames.Length; i++) ret.Add(new CharacterFile(filenames[i]));
            ret.ForEach(x => x.Load());
            ret.RemoveAll(x => x.Canceled);
            return ret;
        }
    }
}
