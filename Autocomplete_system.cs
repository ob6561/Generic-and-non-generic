using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic_and_non_generic
{
    
    public class TrieNode
    {
        public bool IsWord { get; set; }
        public Dictionary<char, TrieNode> Children { get; } = new Dictionary<char, TrieNode>();
    }

    
    public class Autocomplete
    {
        private readonly TrieNode _root = new TrieNode();

        
        public void AddWord(string word)
        {
            if (string.IsNullOrWhiteSpace(word))
                return;

            var current = _root;
            foreach (char c in word.ToLower())
            {
                if (!current.Children.ContainsKey(c))
                {
                    current.Children[c] = new TrieNode();
                }
                current = current.Children[c];
            }
            current.IsWord = true;
        }

        
        public void AddWords(IEnumerable<string> words)
        {
            foreach (var word in words)
            {
                AddWord(word);
            }
        }

        
        public List<string> GetSuggestions(string prefix, int maxSuggestions = 10)
        {
            var results = new List<string>();

            if (prefix == null)
                return results;

            prefix = prefix.ToLower();
            var current = _root;

            
            foreach (char c in prefix)
            {
                if (!current.Children.ContainsKey(c))
                {
                    
                    return results;
                }
                current = current.Children[c];
            }

            
            DFS(current, prefix, results, maxSuggestions);
            return results;
        }

        
        private void DFS(TrieNode node, string currentPrefix, List<string> results, int maxSuggestions)
        {
            if (results.Count >= maxSuggestions)
                return;

            if (node.IsWord)
            {
                results.Add(currentPrefix);
            }

            foreach (var kvp in node.Children)
            {
                char nextChar = kvp.Key;
                TrieNode childNode = kvp.Value;
                DFS(childNode, currentPrefix + nextChar, results, maxSuggestions);

                if (results.Count >= maxSuggestions)
                    return;
            }
        }
    }
    internal class Autocomplete_system
    {
        static void Main(string[] args)
        {
            var autocomplete = new Autocomplete();

            
            var words = new[]
            {
                "apple", "app", "application", "apply", "apt",
                "banana", "band", "bandwidth", "bandit",
                "cat", "catalog", "cater", "caterpillar"
            };

            autocomplete.AddWords(words);

            while (true)
            {
                Console.Write("Type a prefix (or 'exit'): ");
                string input = Console.ReadLine();

                if (input == null || input.Equals("exit", StringComparison.OrdinalIgnoreCase))
                    break;

                var suggestions = autocomplete.GetSuggestions(input, maxSuggestions: 5);

                Console.WriteLine("Suggestions:");
                if (suggestions.Count == 0)
                {
                    Console.WriteLine("  (no matches)");
                }
                else
                {
                    foreach (var suggestion in suggestions)
                    {
                        Console.WriteLine("  " + suggestion);
                    }
                }

                Console.WriteLine();
            }
        }
    }
}
