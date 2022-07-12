using System;

namespace MinimumWindowSubstring
{
    class Program
    {
        static void Main(string[] args)
        {
            s = "ADOBECODEBANC", t = "ABC";
            Console.WriteLine("The minimum window substring " + t + " includes 'A', 'B', and 'C' from string t "+minWindow(s,t));
        }

        public string minWindow(String s, String t) {
        int[] map = new int[128];
        char[] arr = s.ToCharArray();
        //Set up the table
        for(char cur : t.ToCharArray()){
            map[cur]++;
        }
        
        int countAllCharInT = 0;
        int left = 0, n = arr.Length, right = 0;
        int minLen = Int32.MaxValue;
        String minLenStr = "";
        
        while(right < n){
            //Expand the window
            map[arr[right]]--;
            if(0 <= map[arr[right]]){
                countAllCharInT++;         
            }
            
            //Shrink the window if current window contains all the char in t
            while(countAllCharInT == t.Length){
                //Update the minLen
                if(minLen > right - left + 1){
                    minLen = right - left + 1;
                    minLenStr = s.Substring(left, right + 1);
                }
                
                //Shrink the window
                map[arr[left]]++;
                if(0 < map[arr[left]]){
                    countAllCharInT--;
                }
                left++;
            }
            
            right++;
        }
        
        return minLenStr;
    }
    }
}
