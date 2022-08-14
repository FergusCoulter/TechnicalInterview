using System;
namespace TechnicalInterview
{
    public interface Deck<T>
    {
        public IEnumerable<T> Deck { get; set; }


        public void Shuffle();

        public void Sort();

        public void Swap(int indexOne, int indexTwo);
        

        
    }
}

