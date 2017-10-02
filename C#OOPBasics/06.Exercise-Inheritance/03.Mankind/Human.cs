﻿using System;

public class Human
{
    private string firstName;
    private string lastName;

    public Human(string firstName, string lastName)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
    }

    public string LastName
    {
        get { return this.lastName; }
        set
        {
            if (value[0] < 'A' || value[0] > 'Z')
            {
                throw new ArgumentException("Expected upper case letter! Argument: lastName");
            }

            if (value.Length < 3)
            {
                throw new ArgumentException("Expected length at least 3 symbols! Argument: lastName");
            }
            this.lastName = value;
        }
    }


    public string FirstName
    {
        get { return this.firstName; }
        set
        {
            if (value[0] < 'A' || value[0] > 'Z')
            {
                throw new ArgumentException("Expected upper case letter! Argument: firstName");
            }

            if (value.Length < 4)
            {
                throw new ArgumentException("Expected length at least 4 symbols! Argument: firstName");
            }
            this.firstName = value;
        }
    }

    public override string ToString()
    {
        return $"First Name: {this.FirstName}\nLast Name: {this.LastName}\n";
    }
}
