ALTER TABLE SessionDetails
ADD FOREIGN KEY (TrainerId) REFERENCES Participant(ParticipantId);

ALTER TABLE SessionDetails
ALTER COLUMN TrainerId int NOT NULL;

ALTER TABLE SessionDetails
ADD FOREIGN KEY (SessionTypeId) REFERENCES SessionType(Id);

ALTER TABLE SessionDetails
ALTER COLUMN SessionTypeId int NOT NULL;

ALTER TABLE SessionParticipantsMapping
ADD FOREIGN KEY (ParticipantId) REFERENCES Participant(ParticipantId);

ALTER TABLE SessionDetails
ALTER COLUMN TrainerId int NOT NULL;

ALTER TABLE SessionParticipantsMapping
ADD FOREIGN KEY (SessionDetailsId) REFERENCES SessionDetails(Id);

ALTER TABLE SessionDetails
ALTER COLUMN SessionTypeId int NOT NULL;

ALTER TABLE ParticipantIntrests
ADD FOREIGN KEY (ParticipantID) REFERENCES Participant(ParticipantId);

ALTER TABLE ParticipantIntrests
ADD FOREIGN KEY (SessionTypeId) REFERENCES SessionType(Id);
