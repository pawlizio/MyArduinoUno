//Source code for the Arduino



void setup() {

}

void loop() {

	// Call serial output for My Arduino Uno
	serialOUT();
}

void serialOUT(){
	/*
	This is my Protocol to transfer data:value between Arduino Uno and the serial port
	http://www.netzmafia.de/skripten/hardware/Arduino/programmierung.html
	http://www.arduino.cc/en/Reference/PortManipulation
	*/

	// Status of digital PIN 0 - 7 whether INPUT=0 or OUTPUT=1 
	Serial.print("DDRD:");
	Serial.println(DDRD);

	// Status of digital PIN 8 - 13 whether INPUT=0 or OUTPUT=1
	Serial.print("DDRB:");
	Serial.println(DDRB);

	// Status of analog PIN 0 - 5 whether INPUT=0 or OUTPUT=1
	Serial.print("DDRC:");
	Serial.println(DDRC);

	// Status of digtal PIN 0 - 7 whether LOW=0 or HIGH=1
	// PORTD maps to Arduino digital pins 0 to 7
	Serial.print("PORTD:");
	Serial.println(PORTD);

	// Status of digtal PIN 8 - 13 whether LOW=0 or HIGH=1
	// PORTB maps to Arduino digital pins 8 to 13 The two high bits(6 & 7) map to the crystal pins and are not usable
	Serial.print("PORTB:");
	Serial.println(PORTB);

	// Status of analog PIN 0 - 5 whether LOW=0 or HIGH=1
	// PORTC maps to Arduino analog pins 0 to 5
	Serial.print("PORTC:");
	Serial.println(PORTC);

	// Submits the value of the analog input A0
	Serial.print("AOVAL:");
	Serial.println(analogRead(0));
	
	// Submits the value of the analog input A1
	Serial.print("A1VAL:");
	Serial.println(analogRead(1));

	// Submits the value of the analog input A2
	Serial.print("A2VAL:");
	Serial.println(analogRead(2));

	// Submits the value of the analog input A3
	Serial.print("A3VAL:");
	Serial.println(analogRead(3));

	// Submits the value of the analog input A4
	Serial.print("A4VAL:");
	Serial.println(analogRead(4));

	// Submits the value of the analog input A5
	Serial.print("A5VAL:");
	Serial.println(analogRead(5));

	//To check whether Pin Pins 5 and 6 use PWM
	// Serial.print("TCCR0A: ");
	//Serial.println(TCCR0A);
	// To check whether Pins 9 and 10 use PWM
	// Serial.print("TCCR1A: ");
	//Serial.println(TCCR1A);
	// To check whether Pins 11 and 3 use PWM
	// Serial.print("TCCR2A: ");
	//Serial.println(TCCR2A, BIN);
}

void serialIN(){

}