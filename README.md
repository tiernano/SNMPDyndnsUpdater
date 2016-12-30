# SNMPDyndnsUpdater

#What is it?
currently test code for talking to a server over SNMP and getting a list of interfaces from it, including their IP and names

#Why?
Well, i know there are tools like [icanhazip](http://icanhazip.com) and [ifcfg.me](https://ifcfg.me/) but they work well if you only have a single WAN port... I have 2, so I need a way of asking my router for IPs...

#But PFSense can do this!
yea, using Dynamic DNS, PFSense can do this... but i have a shead load of domains, and multiple WAN links, and different providers... so i am going to build something new and magical!

#Whats next?
Tasks:
* ~~find ips and names via snmp~~
* make configurable
* make plugins for updating dynamic IP services 
 * [CloudFlare](http://www.cloudflare.com)
 * [DynDNS](http://www.dyndns.org)
 * [Amazon Route53](http://aws.amazon.com/route53)
 * [ClouDNS](https://www.cloudns.net/)
 * others...
* Run as a Service
* ~~.NET Core Support~~ see the SNMPDyndnsUpdater.Core project (tested in linux)
* Run in a docker container
