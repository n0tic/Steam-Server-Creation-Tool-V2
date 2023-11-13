<?php

function scanPort($ip, $port, $protocol = 'tcp', $timeout = 1) {
    $socket = @fsockopen($ip, $port, $errno, $errstr, $timeout);
    
    if ($socket) {
        fclose($socket);
        return "$protocol is open";
    } else {
        return "$protocol is closed";
    }
}

$response = array("IP" => "", "TCP" => "", "UDP" => "");

if (isset($_GET['ip'])) {
    $ip = $_GET['ip'];

    if (isset($_GET['port'])) {
        $port = $_GET['port'];

        // Validate input
        if (!filter_var($ip, FILTER_VALIDATE_IP) === false && is_numeric($port)) {
            // TCP scan
            $response['TCP'] = scanPort($ip, $port, 'TCP');

            // UDP scan
            $response['UDP'] = scanPort($ip, $port, 'UDP');
        } else {
            $response['IP'] = "Invalid IP or port number";
        }
    }

    $response['IP'] = $ip;
} else {
    $response['IP'] = $_SERVER['REMOTE_ADDR'];
}

// Output JSON response
echo json_encode($response);
?>