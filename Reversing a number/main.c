#include <stdio.h>
#include <math.h>

int obrnut (int n)
{
	int broj_okrenut=0,brojac=0,b,a,i;
	b=n;
	while (b!=0)
	{
		a=b%10;
		brojac++;
		b/=10;

	}
	for (i=brojac-1;i>=0;i--)
	{
		a=0;
		a=n%10;
		a=a*pow(10,i);
		broj_okrenut+=a;
		n/=10;
	}
	return broj_okrenut;
}
int main() {
    int n;
	printf("Unesite broj: ");
	scanf("%d",&n);
	printf("Broj okrenut naopako glasi %d",obrnut(n));
	return 0;
}
