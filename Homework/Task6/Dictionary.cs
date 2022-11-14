using System;
using System.Collections.Generic;


namespace Homework.Task6
{
    interface IDict
    {
        void Add(string word, string translation);
        HashSet<string> GetTranslations(string word);
        int Size();

    }
    public class Dict : IDict
    {
        private static Dict instance;
        private Dictionary<string, HashSet<string>> translations;
        private Dict()
        {
            initDict();
        }
        public static Dict Instance()
        {
            if (instance == null)
            {
                instance = new Dict();
            }
            return instance;
        }
        public void Add(string word, string translation)
        {
            Add(word, translation, true);
        }

        public HashSet<string> GetTranslations(string word)
        {
            HashSet<string> outSet;
            return translations.TryGetValue(word, out outSet) ?
                new HashSet<string>(outSet) :
                new HashSet<string>();
        }

        public int Size()
        {
            return translations.Count;
        }

        // for testing only, can be private and accessed via reflection
        public void Clean()
        {
            translations.Clear();
            instance = null;
        }

        private void Add(string word, string translation, bool addReverse)
        {
            if (translations.ContainsKey(word))
            {
                HashSet<string> existing;
                translations.TryGetValue(word, out existing);
                translations.Remove(word);
                existing.Add(translation);
                translations.Add(word, existing);
            }
            else
            {
                translations.Add(word, new HashSet<string> { translation });
            }

            if (addReverse)
            {
                Add(translation, word, false);
            }
        }

        private void initDict()
        {
            translations = new Dictionary<string, HashSet<string>>();
            translations.Add("идти", new HashSet<string> { "go", "walk", "move" });
            translations.Add("go", new HashSet<string> { "идти" });
            translations.Add("walk", new HashSet<string> { "идти", "гулять" });
            translations.Add("move", new HashSet<string> { "идти", "двигать" });
            translations.Add("гулять", new HashSet<string> { "walk" });
            translations.Add("двигать", new HashSet<string> { "move" });
            translations.Add("дом", new HashSet<string> { "house", "home" });
            translations.Add("house", new HashSet<string> { "дом" });
            translations.Add("home", new HashSet<string> { "дом" });
            translations.Add("schedule", new HashSet<string> { "расписание", "график" });
            translations.Add("расписание", new HashSet<string> { "schedule" });
            translations.Add("график", new HashSet<string> { "schedule" });
        }
    }
}
