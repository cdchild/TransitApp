INSERT INTO [Agency] ( agency_phone, agency_url, agency_id, agency_name, agency_timezone, agency_lang ) VALUES
 ('888-RIDE-UTA', 'http://www.rideuta.com', '', 'Utah Transit Authority', 'America/Denver', 'en')

 INSERT INTO [Calendar] ( service_id, start_date, end_date, monday, tuesday, wednesday, thursday, friday, saturday, sunday ) VALUES
 
 INSERT INTO [CalendarDate] ( service_id, date, exception_type ) VALUES
 
 INSERT INTO [Route] ( route_long_name, route_type, route_text_color, route_color, agency_id, route_id, route_url, route_desc, route_short_name ) VALUES
 
 INSERT INTO [Shape] ( shape_id, shape_pt_lat, shape_pt_lon, shape_pt_sequence, shape_dist_traveled ) VALUES
 
 INSERT INTO [StopTime] ( trip_id, arrival_time, departure_time, stop_id, stop_sequence, stop_headsign, pickup_type, drop_off_type, shape_dist_traveled ) VALUES
 
 INSERT INTO [Stop] ( stop_lat, stop_code, stop_lon, stop_id, stop_url, parent_station, stop_desc, stop_name, location_type, zone_id) VALUES
 
 INSERT INTO [Trip] ( block_id, route_id, direction_id, trip_headsign, shape_id, service_id, trip_id ) VALUES
 