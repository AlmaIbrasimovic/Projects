#include <stdio.h>
#include <stdlib.h>
#define VEL 100

int main()
{
    int j,m,niz[VEL],n,i,brojac=-1;

    printf("Unesite elemente niza (-1 za prekid unosa): ");
    for (i=0;i<VEL;i++)
    {
        scanf("%d",&n);
        brojac++;
        if (n==-1) break;
        niz[i]=n;
    }
    printf("Unesite broj koji zelite izbaciti: ");
    scanf("%d",&m);
    for (i=0;i<brojac;i++)
    {
        if (niz[i]==m)
        {
            for (j=i;j<brojac-1;j++)
            {
                niz[j]=niz[j+1];
            }
        brojac--;
        i--;
        }
    }
    printf ("Elementi novog niza su: ");
    for(i=0;i<brojac;i++) {
            if (i==brojac-1)
            printf("%d",niz[i]);
    else
    printf ("%d,", niz[i]);
    }
    return 0;
}
