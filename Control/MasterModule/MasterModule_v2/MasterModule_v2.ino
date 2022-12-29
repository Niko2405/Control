const int BAUD = 9600;
const String VERSION = "Version 2.0";

String message;

void setup() {
  Serial.begin(BAUD);
  Serial.setTimeout(100);

  pinMode(13, OUTPUT);
}

void loop() {
  if (Serial.available() > 0) {
    message = Serial.readString();
    message.replace("\r", "");
    message.replace("\n", "");

    if (message == "TEST") {
      Serial.println("OK");
    }
    else if (message == "GET VERSION") {
      Serial.println(VERSION);
    }
    else if (message == "SET 13 HIGH") {
        digitalWrite(13, HIGH);
        Serial.println("OK");
    }
    else if (message == "SET 13 LOW") {
      digitalWrite(13, LOW);
      Serial.println("OK");
    }
    else {
      Serial.println("NO COMMAND FOUND");
    }
  }
}
