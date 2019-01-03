#include <stdio.h>
#include <math.h>

long long int faktorijel (int n)
{
	int i,fact=1;
	for (i=2;i<=n;i++)
	{
		fact=fact*i;
	}
	return fact;
}
double sinus (double x,int n)
{
	double suma=0;
	int i;
	for (i=1;i<=n;i++)
	{
		suma+=(double)pow(-1,i-1)*(pow(x,2*i-1)/faktorijel(2*i-1));

	}
	return suma;
}
int main() {
	double x;
	double b;
	int n;
	printf("Unesite x: ");
	scanf("%lf",&x);
	printf("\nUnesite n: ");
	scanf("%d",&n);
	b=sinus(x,n);
	printf("\nsin(x)=%lf",b);
	printf("\nsinus(x)=%g",sin(x));
	double razlika;
	razlika=sin(x)-b;
	if(razlika<0)
	razlika*=-1;
	printf("\nRazlika: %lf (%.2lf%).",razlika,razlika*100);
	return 0;
}
