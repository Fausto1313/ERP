<?php
	$v1 = $_GET["v1"]; 
	$v2 = $_GET["v2"]; 
	$url = "http://". $v1 ."/alarma.php?alarma=". $v2;
	//$curl = curl_init();
	//curl_setopt($curl, CURLOPT_URL, $url);

	//$output = curl_exec($curl);
	//curl_close($curl);
	//print_r($output);
	$validStatus=array(200/*,301,302*/);
	$ch=curl_init();
    curl_setopt($ch, CURLOPT_URL, $url);
    curl_setopt($ch, CURLOPT_HEADER, true);
    curl_setopt($ch, CURLOPT_RETURNTRANSFER, 1);
    $headers = [
      'Accept:text/html,application/xhtml+xml,application/xml;q=0.9,/;q=0.8',

      'User-Agent: Mozilla/5.0 (Windows; U; Windows NT 5.1; es-MX; rv:1.8.1.13) Gecko/20080311 Firefox/2.0.0.13',

      'Connection: Keep-Alive',

      'Accept-Encoding: gzip, deflate',

      'Accept-Language: Es-Es,*'
    ];
    curl_setopt($ch, CURLOPT_HTTPHEADER, $headers);

    $response=curl_exec($ch);
    $info=curl_getinfo($ch);
    $statusCode=intval($info['http_code']);
    if(!in_array($statusCode,$validStatus)) {
    	echo "False";
    }
    else
    	echo "True";

?>