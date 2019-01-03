#include <stdio.h>
#include <stdlib.h>
#define VEL 100

int main()
{
    int mat[VEL][VEL],A,B,i,j,suma=0;
    printf("Unesite dimenziju matrica AxB: ");
    scanf("%d%d",&A,&B);
    printf("Unesite elemente matrice:\n");
    for (i=0;i<A;i++)
    {
        for (j=0;j<B;j++)
        {
            printf("Unesite element [%d][%d]:",i+1,j+1);
            scanf("%d",&mat[i][j]);
        }
    }
    printf("Unijeli ste matricu:\n");
    for (i=0;i<A;i++)
    {
        for (j=0;j<B;j++)
        {
            printf("%5d",mat[i][j]);

        }
        printf("\n");
    }

    for (i=0;i<A;i++)
    {
        for (j=0;j<B;j++)
        {
            if (i==0 || i==A-1 || j==0 || j==B-1)

                suma+=mat[i][j];
        }
    }
    printf("Trazena suma na rubu matrice je %d",suma);
    return 0;
}
