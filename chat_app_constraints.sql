
alter table dbo.userr add 
primary key (id) ;

alter table dbo.user_message
add constraint FK_sender FOREIGN key (sender_id)
references userr(id) ;

alter table dbo.user_message
add constraint FK_Receiver 
FOREIGN KEY (receiver_id)
references userr(id)
