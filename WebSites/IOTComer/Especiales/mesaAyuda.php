<?php
$v1 = $_GET["v1"]; 
$v2 = $_GET["v2"]; 
$v3 = $_GET["v3"];
$url ="http://monitoreo.addar.mx/DarCtrl.php?noip=".$v1."&descripciondar=".$v2."&ubicacion=".$v3."&accion=InserDar";
$curl = curl_init();
	curl_setopt($curl, CURLOPT_URL, $url);

	$output = curl_exec($curl);
	curl_close($curl);
	print_r($output);
?>