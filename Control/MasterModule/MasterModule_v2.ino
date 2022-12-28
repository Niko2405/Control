const int BAUD = 9600;
const String VERSION = "Version 2.0";

String message;

void setup() {
  Serial.begin(BAUD);
  Serial.setTimeout(100);
  Serial.println(VERSION);
}

void loop() {
  if (Serial.available() > 0) {
    message = Serial.readString();
    if (message == "TEST") {
      Serial.println("OK");
    }
    if (message == "GET VERSION") {
      Serial.println(VERSION);
    }
    else {
      Serial.println("NO COMMAND FOUND");
    }
  }
}
