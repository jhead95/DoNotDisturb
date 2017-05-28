int led1 = 2;
int led2 = 3;
int led3 = 4;
int led4 = 5;
int led5 = 6;
int led6 = 7;
char myCol[20];

void setup() {
  // put your setup code here, to run once:
  Serial.begin (9600); 
  pinMode(led1, OUTPUT);
  pinMode(led2, OUTPUT);
  pinMode(led3, OUTPUT);
  pinMode(led4, OUTPUT);
  pinMode(led5, OUTPUT);
  pinMode(led6, OUTPUT);

  digitalWrite(led1, LOW);
  digitalWrite(led2, LOW);
  digitalWrite(led3, LOW);
  digitalWrite(led4, LOW);
  digitalWrite(led5, LOW);
  digitalWrite(led6, LOW);
}

void loop() {
  // put your main code here, to run repeatedly:
/**digitalWrite(led1, HIGH);
delay(1000);
digitalWrite(led1, LOW);
digitalWrite(led2, HIGH);
delay(1000);
digitalWrite(led2, LOW);**/

  int lf = 10;
  Serial.readBytesUntil(lf, myCol, 1);
  
  //Stretch 1 Blinking
  while(strcmp(myCol,"a")==0){
       digitalWrite(led1, LOW);       
       digitalWrite(led2, LOW); 
       digitalWrite(led3, LOW);
       digitalWrite(led4, LOW);
       digitalWrite(led5, LOW);
       digitalWrite(led6, HIGH);

       delay(600);

       digitalWrite(led6, LOW);


       break;
  }
  
  //Stretch 1 Solid
   if(strcmp(myCol,"1")==0){
       digitalWrite(led1, LOW);       
       digitalWrite(led2, LOW); 
       digitalWrite(led3, LOW);
       digitalWrite(led4, LOW);
       digitalWrite(led5, LOW);
       digitalWrite(led6, HIGH);  
   }

  //Stretch 2 Blinking
  while(strcmp(myCol,"b")==0){
       digitalWrite(led1, LOW);       
       digitalWrite(led2, LOW); 
       digitalWrite(led3, LOW);
       digitalWrite(led4, LOW);
       digitalWrite(led5, HIGH);
       digitalWrite(led6, LOW);

       delay(600);

       digitalWrite(led5, LOW);


       break;
  }
  
   //Stretch 2 Solid
   if(strcmp(myCol,"2")==0){
       digitalWrite(led1, LOW);       
       digitalWrite(led2, LOW); 
       digitalWrite(led3, LOW);
       digitalWrite(led4, LOW);
       digitalWrite(led5, HIGH);
       digitalWrite(led6, LOW);   
   }

   //Stretch 3 Blinking
  while(strcmp(myCol,"c")==0){
       digitalWrite(led1, LOW);       
       digitalWrite(led2, HIGH); 
       digitalWrite(led3, LOW);
       digitalWrite(led4, LOW);
       digitalWrite(led5, LOW);
       digitalWrite(led6, LOW);

       delay(600);

       digitalWrite(led2, LOW);


       break;
  }
  
   //Stretch 3 Solid
   if(strcmp(myCol,"3")==0){
       digitalWrite(led1, LOW);       
       digitalWrite(led2, HIGH); 
       digitalWrite(led3, LOW);
       digitalWrite(led4, LOW);
       digitalWrite(led5, LOW);
       digitalWrite(led6, LOW);    
   }

  //Stretch 4 Blinking
  while(strcmp(myCol,"d")==0){
       digitalWrite(led1, HIGH);       
       digitalWrite(led2, LOW); 
       digitalWrite(led3, LOW);
       digitalWrite(led4, LOW);
       digitalWrite(led5, LOW);
       digitalWrite(led6, LOW);

       delay(600);

       digitalWrite(led1, LOW);


       break;
  }
  
   //Stretch 4 Solid
   if(strcmp(myCol,"4")==0){
       digitalWrite(led1, HIGH);       
       digitalWrite(led2, LOW); 
       digitalWrite(led3, LOW);
       digitalWrite(led4, LOW);
       digitalWrite(led5, LOW);
       digitalWrite(led6, LOW);    
   }

  //Stretch 5 Blinking
  while(strcmp(myCol,"e")==0){
       digitalWrite(led1, LOW);       
       digitalWrite(led2, HIGH); 
       digitalWrite(led3, HIGH);
       digitalWrite(led4, LOW);
       digitalWrite(led5, LOW);
       digitalWrite(led6, LOW);

       delay(600);

       digitalWrite(led2, LOW);
       digitalWrite(led3, LOW);


       break;
  }
   //Stretch 5 Solid
   if(strcmp(myCol,"5")==0){
       digitalWrite(led1, LOW);       
       digitalWrite(led2, HIGH); 
       digitalWrite(led3, HIGH);
       digitalWrite(led4, LOW);
       digitalWrite(led5, LOW);
       digitalWrite(led6, LOW);    
   }

  //Stretch 6 Blinking
  while(strcmp(myCol,"f")==0){
       digitalWrite(led1, HIGH);       
       digitalWrite(led2, LOW); 
       digitalWrite(led3, LOW);
       digitalWrite(led4, HIGH);
       digitalWrite(led5, LOW);
       digitalWrite(led6, LOW);

       delay(600);

       digitalWrite(led1, LOW);
       digitalWrite(led4, LOW);


       break;
  }
  
   //Stretch 6 Solid
   if(strcmp(myCol,"6")==0){
       digitalWrite(led1, HIGH);       
       digitalWrite(led2, LOW); 
       digitalWrite(led3, LOW);
       digitalWrite(led4, HIGH);
       digitalWrite(led5, LOW);
       digitalWrite(led6, LOW);    
   }

    //Stretch 7 Blinking
  while(strcmp(myCol,"g")==0){
       digitalWrite(led1, LOW);       
       digitalWrite(led2, LOW); 
       digitalWrite(led3, LOW);
       digitalWrite(led4, LOW);
       digitalWrite(led5, HIGH);
       digitalWrite(led6, HIGH);

       delay(600);

       digitalWrite(led5, LOW);
       digitalWrite(led6, LOW);


       break;
  }
  
   //Stretch 7 Solid
   if(strcmp(myCol,"7")==0){
       digitalWrite(led1, LOW);       
       digitalWrite(led2, LOW); 
       digitalWrite(led3, LOW);
       digitalWrite(led4, LOW);
       digitalWrite(led5, HIGH);
       digitalWrite(led6, HIGH);    
   }

     //Stretch 8 Blinking
  while(strcmp(myCol,"h")==0){
       digitalWrite(led1, LOW);       
       digitalWrite(led2, HIGH); 
       digitalWrite(led3, LOW);
       digitalWrite(led4, HIGH);
       digitalWrite(led5, LOW);
       digitalWrite(led6, LOW);

       delay(600);

       digitalWrite(led2, LOW);
       digitalWrite(led4, LOW);


       break;
  }
  
   //Stretch 8 Solid
   if(strcmp(myCol,"8")==0){
       digitalWrite(led1, LOW);       
       digitalWrite(led2, HIGH); 
       digitalWrite(led3, LOW);
       digitalWrite(led4, HIGH);
       digitalWrite(led5, LOW);
       digitalWrite(led6, LOW);    
   }

     //Stretch 9 Blinking
  while(strcmp(myCol,"i")==0){
       digitalWrite(led1, HIGH);       
       digitalWrite(led2, LOW); 
       digitalWrite(led3, HIGH);
       digitalWrite(led4, LOW);
       digitalWrite(led5, LOW);
       digitalWrite(led6, LOW);

       delay(600);

       digitalWrite(led1, LOW);
       digitalWrite(led3, LOW);


       break;
  }
  
   //Stretch 9 Solid
   if(strcmp(myCol,"9")==0){
       digitalWrite(led1, HIGH);       
       digitalWrite(led2, LOW); 
       digitalWrite(led3, HIGH);
       digitalWrite(led4, LOW);
       digitalWrite(led5, LOW);
       digitalWrite(led6, LOW);    
   }

   //Lights Off
   if(strcmp(myCol,"0")==0){
       digitalWrite(led1, LOW);       
       digitalWrite(led2, LOW); 
       digitalWrite(led3, LOW);
       digitalWrite(led4, LOW);
       digitalWrite(led5, LOW);
       digitalWrite(led6, LOW);    
   }

   if(strcmp(myCol,"x")==0){
       Serial.write("z"); 
   }
   
}
