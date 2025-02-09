<?php

function scanTCP($ip, $port, $timeout = 1) {
    $socket = @fsockopen($ip, $port, $errno, $errstr, $timeout);
    
    if ($socket) {
        fclose($socket);
        return "TCP is open";
    } else {
        return "TCP is closed";
    }
}

function scanUDP($ip, $port, $timeout = 1) {
    $socket = socket_create(AF_INET, SOCK_DGRAM, SOL_UDP);
    
    if (!$socket) {
        return "UDP is closed"; // Maintain original format
    }

    // Set timeout to avoid long hangs
    socket_set_option($socket, SOL_SOCKET, SO_RCVTIMEO, ["sec" => $timeout, "usec" => 0]);

    // Send empty packet
    $msg = "ping";
    $len = strlen($msg);
    socket_sendto($socket, $msg, $len, 0, $ip, $port);

    // Try to receive response
    $buf = "";
    $from = "";
    $portOut = 0;
    $result = @socket_recvfrom($socket, $buf, 512, 0, $from, $portOut);

    socket_close($socket);

    return ($result === false) ? "UDP is closed" : "UDP is open";
}

$response = ["IP" => "", "TCP" => "", "UDP" => ""];

if (isset($_GET['ip']) && isset($_GET['port'])) {
    $ip = $_GET['ip'];
    $port = $_GET['port'];

    if (filter_var($ip, FILTER_VALIDATE_IP) && is_numeric($port) && $port > 0 && $port <= 65535) {
        $response['TCP'] = scanTCP($ip, $port);
        //$response['UDP'] = scanUDP($ip, $port);
        $response['UDP'] = "UDP scan not supported on this server";
    } else {
        $response['IP'] = "Invalid IP or port number";
    }

    $response['IP'] = $ip;
} else {
    $response['IP'] = $_SERVER['REMOTE_ADDR'];
}

// Output JSON response
echo json_encode($response);
?>
