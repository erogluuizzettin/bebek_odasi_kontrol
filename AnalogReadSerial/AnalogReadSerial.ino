#include <LiquidCrystal.h>
LiquidCrystal lcd(30,32,31,33,35,37);

int pin_analog = A5;
int pin_digital = 8;
int Analog_Deger = 0;
int Digital_Deger = 0;

float sicaklik_derecesi;
float gerilim_degeri;
int sicaklik_derecesiPin = 0; // analog girişin olacağı pin
int yesil_led = 11;        // yeşil led çıkış
int sari_led =12;          // sarı led
int kirmizii_led = 13; // kırmızı led

int pot1,pot2;



void setup() {
  Serial.begin(9600);
  pinMode(3, OUTPUT);
  pinMode(4, OUTPUT);
  pinMode(5, OUTPUT);
  pinMode(6, OUTPUT);
  pinMode(pin_analog, INPUT);
  pinMode(pin_digital, INPUT);

  pinMode( yesil_led, OUTPUT);         
  pinMode( sari_led, OUTPUT);            
  pinMode( kirmizii_led, OUTPUT);

  
  
}
 
void loop() {
  
  Analog_Deger = analogRead(pin_analog);
  Digital_Deger = digitalRead(pin_digital);
      
  
   
 
  if (Analog_Deger >= 31) { //Eğer algılanan ses seviyesi belirlediğimiz değerden büyükse
    digitalWrite(3, HIGH);
    digitalWrite(4, LOW);
    digitalWrite(5, LOW);
    digitalWrite(6, LOW);
    delay(250);
  }
  if (Analog_Deger >= 32) { //Eğer algılanan ses seviyesi belirlediğimiz değerden büyükse
    digitalWrite(3, HIGH);
    digitalWrite(4, HIGH);
    digitalWrite(5, LOW);
    digitalWrite(6, LOW);
    delay(250);
  }
  if (Analog_Deger >= 33) { //Eğer algılanan ses seviyesi belirlediğimiz değerden büyükse
    digitalWrite(3, HIGH);
    digitalWrite(4, HIGH);
    digitalWrite(5, HIGH);
    digitalWrite(6, LOW);
    delay(250);
  }
  if (Analog_Deger >= 35) { //Eğer algılanan ses seviyesi belirlediğimiz değerden büyükse
    digitalWrite(3, HIGH);
    digitalWrite(4, HIGH);
    digitalWrite(5, HIGH);
    digitalWrite(6, HIGH);
    delay(250);
  }
    
    delay(500);
    digitalWrite(3, LOW);
    digitalWrite(4, LOW);
    digitalWrite(5, LOW);
    digitalWrite(6, LOW);

    gerilim_degeri = analogRead(sicaklik_derecesiPin);       // analog degeri oku
gerilim_degeri = (gerilim_degeri/1023)*5000;                // analog deger mv ye çevirir.
sicaklik_derecesi = gerilim_degeri/10.0;                            // celciusa çevirip sicakliğa atadık.

// bulduğumuz değer aralığına göre yanacak ledleri belirliyoruz.
if ( sicaklik_derecesi < 23 )
{
digitalWrite ( yesil_led , HIGH );     // yeşil ledi yak
digitalWrite ( sari_led , LOW );         //
digitalWrite ( kirmizii_led , LOW ); //
}
else if( (sicaklik_derecesi >=23) && ( sicaklik_derecesi < 25) )
{
digitalWrite ( yesil_led , LOW );      // yeşil ledi söndür
digitalWrite ( sari_led , HIGH );       // sarı ledi yak
digitalWrite ( kirmizii_led , LOW ); // kırmızı ledi söndür
}
else if( (sicaklik_derecesi >=25) && ( sicaklik_derecesi < 28) )
{
digitalWrite ( yesil_led , LOW );            // yeşil ledi söndür
digitalWrite ( sari_led , LOW );               // sarı ledi söndür
digitalWrite ( kirmizii_led , HIGH );      // kırmızı ledi yak
}
else if( sicaklik_derecesi >=28 )
{
digitalWrite ( yesil_led , HIGH );         // yeşil ledi yak
digitalWrite ( sari_led , HIGH );             // sarı ledi söndür
digitalWrite ( kirmizii_led , HIGH );    // kırmızı ledi söndür
delay(250);                                                      //250 milisaniye boyunca yak
                                                       //250 milisaniye boyunca yak
}

// yarım saniyede bir bizde ekranımızdan değeri görelim.
pot1=Analog_Deger;
pot2=(int)sicaklik_derecesi;
Serial.print(pot1);
Serial.print("*");
Serial.println(pot2);

lcd.begin(16,2);
  lcd.clear();
  lcd.print("Ses Degr. : ");
  lcd.print(pot1);
  
  lcd.setCursor(0,1);
  lcd.print("Sicaklik D: ");
  lcd.print(pot2);

delay(500);
  
}
