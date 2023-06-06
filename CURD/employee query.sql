create database employee

create table employee(

emp_id int primary key identity(1,1),
emp_name varchar(200) not null,
emp_email varchar(300) not null unique,
emp_mobile bigint ,
emp_salary bigint,
emp_dept_id int not null
)

create table department(
dept_id int primary key identity(1,1),
dept_name varchar(200) not null unique
)

alter table employee
add constraint fk_dept_id
foreign key (emp_dept_id) references department(dept_id)

INSERT INTO department (dept_name)
VALUES ('Marketing'),
       ('Sales'),
       ('Finance'),
       ('Human Resources'),
       ('Operations'),
       ('Research '),
       ('Information Technology'),
       ('Customer Service'),
       ('Legal'),
       ('Administration');

	   INSERT INTO employee (emp_name, emp_email, emp_mobile, emp_salary, emp_dept_id)
VALUES
    ('John Doe', 'johndoe@example.com', 1234567890, 50000, 1),
    ('Jane Smith', 'janesmith@example.com', 9876543210, 60000, 2),
    ('Michael Johnson', 'michaeljohnson@example.com', 4567890123, 55000, 1),
    ('Emily Davis', 'emilydavis@example.com', 7890123456, 65000, 2),
    ('Robert Wilson', 'robertwilson@example.com', 3210987654, 70000, 3),
    ('Sophia Anderson', 'sophiaanderson@example.com', 5678901234, 60000, 4),
    ('William Thompson', 'williamthompson@example.com', 8901234567, 55000, 3),
    ('Olivia White', 'oliviawhite@example.com', 2345678901, 65000, 4),
    ('James Martinez', 'jamesmartinez@example.com', 6789012345, 70000, 1),
    ('Ava Taylor', 'avataylor@example.com', 9012345678, 60000, 2),
    ('David Anderson', 'davidanderson@example.com', 3456789012, 55000, 1),
    ('Emma Johnson', 'emmajohnson@example.com', 7890123456, 65000, 2),
    ('Daniel Davis', 'danieldavis@example.com', 1234567890, 70000, 3),
    ('Mia Wilson', 'miawilson@example.com', 5678901234, 60000, 4),
    ('Joseph Thompson', 'josephthompson@example.com', 9012345678, 55000, 3),
    ('Isabella White', 'isabellawhite@example.com', 2345678901, 65000, 4),
    ('Jacob Martinez', 'jacobmartinez@example.com', 6789012345, 70000, 1),
    ('Sofia Taylor', 'sofiataylor@example.com', 9012345678, 60000, 2),
    ('Andrew Johnson', 'andrewjohnson@example.com', 3456789012, 55000, 1),
    ('Charlotte Davis', 'charlottedavis@example.com', 7890123456, 65000, 2);
