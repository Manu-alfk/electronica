#include <Separador.h>

Separador s;
//para guardar ordenadamente los datos recividos
String  datosr;
String  dator[]={"0","1","2","3","4","5"};
//para enviar los datos recividos en forma de numeros
int datop[]={0,1,2,3,4,5} ;
//los pines de salida
int pin[]={13,6,7,8,9,10};

void setup() {
  Serial.begin(9600);
 //Serial.println("imprime");
  
  for(int i=0;i<6;i++){
  dator[i]="";
  datop[i]=0;
  pinMode(pin[i],OUTPUT);
}
}

void loop() {
  if (Serial.available()>0) {
    datos();
   respuesta();
  }

}

void datos() {
  //leer datos
  datosr = Serial.readString();
    delay(100);  
  Serial.print(datosr);
  //el tiempo es super importante
  //si es menos de 3 segundos de recivo-envio
  //no se comunicaran efectivamente
 // Serial.println("");
  //Serial.println(datosr);
  
//leer strings
for(int i=0;i<6;i++){
  dator[i]=s.separa(datosr, ',', i);
}
/*
//escribir strings
 for(int i=0;i<6;i++){
    Serial.print("a");
    Serial.print(i);    
    Serial.print(" es: ");
    Serial.println(dator[i]);     
    } 
  Serial.println();  
  */
  
//leer int
for(int i=0;i<6;i++){
  datop[i]=dator[i].toInt() ;
}
/*
//escribir int
 for(int i=0;i<6;i++){
    Serial.print("m");
    Serial.print(i);    
    Serial.print(" es: ");
    Serial.println(datop[i]);   
    } 
   Serial.println();
   Serial.println();
   */
   
}

void respuesta(){
for(int i=0;i<6;i++){
 digitalWrite(pin[i],datop[i]);
 //Serial.println(datop[i]);
}
  
}


#include <Wire.h>

void setup() {
  Wire.begin(); // join i2c bus (address optional for master)
Serial.begin(9600);
}
//102030405060708090001020;
int x = 200,s=900,s1=2,s2=3;
String d="123456789012";
void loop() {
  
  //if(Serial.available()>0){  
  //d = Serial.readString();
  delay(100);// sends one byte
  //x++;
eslave1();
//}
delay(50);
}

void eslave1(){
 String a=d;
   byte tex = a.length()+1;
   Serial.println(tex);
   char Array[tex];       //declaramos un vector de caracteres, el cual va a ser usado para enviar el dato
  a.toCharArray(Array,tex);
  for(int i=0;i<tex;i++){
    Serial.print(Array[i]);
  }
  Serial.println(" ");
Wire.beginTransmission(8);//inicializamos la transmision i2c al esclavo 1
  for(int i=0;i<tex;i++){
    Wire.write(Array[i]); //le enviamos caracter por caracter
  }
  Wire.endTransmission();
  
}


