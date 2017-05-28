int latchPin = 10;
int clockPin = 11;
int dataPin = 9;

int currentPoints = 0;

int incomingByte = 0;

void setup(){
  Serial.begin(9600);
  Serial.println("Starting...");
  pinMode(latchPin, OUTPUT);
  pinMode(clockPin, OUTPUT);
  pinMode(dataPin, OUTPUT);
  startUpSequence();
}

void startUpSequence(){
  const int delayTime = 150;
  updateShiftRegister(0);
  delay(delayTime);
  updateShiftRegister(1);
  delay(delayTime);
  updateShiftRegister(3);
  delay(delayTime);
  updateShiftRegister(7);
  delay(delayTime);
  updateShiftRegister(15);
  delay(delayTime);
  updateShiftRegister(63);
  delay(delayTime);
  updateShiftRegister(127);
  delay(delayTime);
  updateShiftRegister(255);
  delay(delayTime);
  updateShiftRegister(0);
  delay(delayTime);
  updateShiftRegister(255);
  delay(delayTime);
  updateShiftRegister(0);
  delay(delayTime);
  updateShiftRegister(255);
  delay(delayTime);
  updateShiftRegister(0);
  delay(delayTime);
  updateShiftRegister(255);
  delay(delayTime);
  updateShiftRegister(0);
  delay(delayTime);
  updateShiftRegister(255);
  delay(delayTime);
  updateShiftRegister(0);
  delay(delayTime);
}

int power(int value, int y){
  if(y==0){
    return 1;
  }else{
    return value * power(value, y-1);
  }
}

void loop(){
  if(Serial.available() > 0){
    incomingByte = Serial.read() - 53;
    Serial.print(" I received: ");
    Serial.println(incomingByte);
    if(currentPoints+incomingByte > 6){
      currentPoints=6;
    } else if(currentPoints+incomingByte < 0){
      currentPoints = 0;
    } else{
      currentPoints += incomingByte;
    }
    
    
    //delay(10);
  }
  updateShiftRegister(power(2,currentPoints)-1);
}

void updateShiftRegister(int number){
  digitalWrite(latchPin, LOW);
  shiftOut(dataPin, clockPin, MSBFIRST, number);
  digitalWrite(latchPin, HIGH);
}

