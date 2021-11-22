package com.example.crud.converters;

import androidx.room.TypeConverter;

import java.util.Date;

public class DateConverter {

    @TypeConverter
    public static Date timestampToDate(Long value){
        return value == null ? null : new Date(value);
    }

    @TypeConverter
    public static long timestampToDate(Date value){
        return value == null ? null : value.getTime();
    }

}
