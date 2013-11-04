//debug
//BubbleSort Algorithm:
//Please see the output of sorted array and debug:
package bubbleSort;

public class BubbleSort {
    private int array[];
    BubbleSort(){}
    private void initialization()
    {
        int[] arrayInit = {4,-1,16,-5,24};
        array = new int[5];
        System.arraycopy(arrayInit, 0, array, 0, arrayInit.length);
    }
    private void bubbleSort()
    {
        for(int i = 1; i < array.length;i++)
            for(int j = 1; j < array.length - i; j++)
                bubbleSwitch(j,j+1);
    }
    private void bubbleSwitch(int a, int b)
    {
        if(array[a] >= array[b])
        {
            int temp = array[a];
            array[a] = array[b];
            array[b] = temp;
        }
    }
    private void output()
    {
        System.out.println("The result of BubbleSort Algorithm is:");
        for(int k = 0; k < array.length; k++)
            System.out.print(" "+array[k]);
    }
    public static void main(String args[])
    {
        BubbleSort bubblesort = new BubbleSort();
        bubblesort.initialization();
        bubblesort.bubbleSort();
        bubblesort.output();
    }
}