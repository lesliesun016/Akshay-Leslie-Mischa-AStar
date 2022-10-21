using System;
using System.Collections.Generic;

public class PriorityQueue<T>
{
    //comes from: https://gist.github.com/keithcollins/307c3335308fea62db2731265ab44c06

    // I'm using an unsorted array for this example, but ideally this
    // would be a binary heap. There's an open issue for adding a binary
    // heap to the standard C# library: https://github.com/dotnet/corefx/issues/574
    //
    // Until then, find a binary heap class:
    // * https://github.com/BlueRaja/High-Speed-Priority-Queue-for-C-Sharp
    // * http://visualstudiomagazine.com/articles/2012/11/01/priority-queues-with-c.aspx
    // * http://xfleury.github.io/graphsearch.html
    // * http://stackoverflow.com/questions/102398/priority-queue-in-net

    private List<Tuple<T, double>> elements = new List<Tuple<T, double>>(); //declaring variables

	public int Count						//returns the number of items in the list
	{
		get { return elements.Count; }
	}

	public void Enqueue(T item, double priority)		//function to add an item to the list 
	{
		elements.Add(Tuple.New(item, priority));
	}

	public T Dequeue()												//function to find the best item and returns the best item in the list
	{
		int bestIndex = 0;

		for (int i = 0; i < elements.Count; i++) {					//finds the index of the item with the first priority and sets it as the best index
			if (elements[i].Item2 < elements[bestIndex].Item2) {
				bestIndex = i;
			}
		}

		T bestItem = elements[bestIndex].Item1;						//saves the item from the best index as bestItem
		elements.RemoveAt(bestIndex);								// removes the current best item from the list
		return bestItem;											//returns the best item in the list
	}
}