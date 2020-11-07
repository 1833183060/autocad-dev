;; Inno Setup Lisp Plugin Installer Script
;; 
;; Main application lisp file that loads at startup. This file should define
;; the application's command autoloader stubs and perform any necessary
;; initialization, but it should be short and sweet so it doesn't cause
;; any delays at startup.

;; LEGAL NOTICE
;;
;; Copyright 2018 ManuSoft (http://www.manusoft.com)
;; All Rights Reserved
;;
;; The setup script and related sample files may be freely modified and used
;; for any purpose. The script and related sample files may be redistributed
;; if any revisions are clearly documented and this legal notice accompanies
;; all files.
;;
;; ManuSoft disclaims any and all liability for your use of this software.
;; The software is provided "as is" without warranty of any kind, either
;; express or implied.


;; Obtain application installation folder from registry
;; * Rename this function before distributing it with a real plugin!
(defun *NiaoGeTool-GetAppFolder ()
  (vl-string-right-trim "\\/"
    (cond ; Check all three possible registry locations
      ( (vl-registry-read "HKEY_CURRENT_USER\\Software\\NiaoGe\\NiaoGeTool" "InstallPath")
      )
      ( (vl-registry-read "HKEY_LOCAL_MACHINE\\Software\\NiaoGe\\NiaoGeTool" "InstallPath")
      )
      ( (vl-registry-read "HKEY_LOCAL_MACHINE\\Software\\Wow6432Node\\NiaoGe\\NiaoGeTool" "InstallPath")
      )
      ( ""
      )
    )
  )
)


;; Define autoload command stubs
;; * "MyLispPluginCmds" is the lisp filename that implements the commands
(autoload (strcat (vl-string-translate "\\" "/" (*NiaoGeTool-GetAppFolder)) "/" "NiaoGeToolCmds")
  '(
    "MyCommand1"
    "MyCommand2"
   )
)


;; In AutoCAD 2014+, add the app folder to TRUSTEDPATHS
;; * Note that this change will not be undone when the plugin is uninstalled
(
  (lambda (/ trustedpaths appfolder startpos endpos found)
    (if (setq trustedpaths (getvar "TRUSTEDPATHS"))
      (progn
        (setq appfolder (*NiaoGeTool-GetAppFolder))
        (while (and (not found) (setq endpos (vl-string-position (ascii ";") trustedpaths endpos)))
          (setq found
            (eq
              (strcase appfolder)
              (strcase
                (substr
                  trustedpaths
                  (if startpos startpos (setq startpos 1))
                  (- (setq endpos (1+ endpos)) startpos)
                )
              )
            )
          )
          (setq startpos (1+ endpos))
        )
        (if (not found) (setq found (eq appfolder (substr trustedpaths (if startpos startpos 1)))))
        (if (not found) (setvar "TRUSTEDPATHS" (strcat trustedpaths ";" appfolder)))
      )
    )
  )
)


;; NOTE: Please resist the urge to add your app folder to the support path. Your
;; app already knows where its files are at, so just specify a complete path and
;; leave the support path uncluttered. CAD managers will thank you.


(princ "\nMyLispP loaded -- MYCOMMAND1 and MYCOMMAND2 are now available.\n")

(princ)

;;;-----BEGIN-SIGNATURE-----
;;; YAcAADCCB1wGCSqGSIb3DQEHAqCCB00wggdJAgEBMQ8wDQYJKoZIhvcNAQELBQAw
;;; CwYJKoZIhvcNAQcBoIIFZDCCBWAwggRIoAMCAQICDyWu/I85IOePf6JKs6J90TAN
;;; BgkqhkiG9w0BAQsFADB9MQswCQYDVQQGEwJHQjEbMBkGA1UECBMSR3JlYXRlciBN
;;; YW5jaGVzdGVyMRAwDgYDVQQHEwdTYWxmb3JkMRowGAYDVQQKExFDT01PRE8gQ0Eg
;;; TGltaXRlZDEjMCEGA1UEAxMaQ09NT0RPIFJTQSBDb2RlIFNpZ25pbmcgQ0EwHhcN
;;; MTgwMjIzMDAwMDAwWhcNMjAwMjIzMjM1OTU5WjCBqTELMAkGA1UEBhMCVVMxDjAM
;;; BgNVBBEMBTQ0NjA2MQ0wCwYDVQQIDARvaGlvMRQwEgYDVQQHDAtBcHBsZSBDcmVl
;;; azEVMBMGA1UECQwMMzQgTWFwbGUgU3QuMRIwEAYDVQQSDAlQT0JveCAxMDExETAP
;;; BgNVBAoMCE1hbnVTb2Z0MRQwEgYDVQQLDAtFbmdpbmVlcmluZzERMA8GA1UEAwwI
;;; TWFudVNvZnQwggEiMA0GCSqGSIb3DQEBAQUAA4IBDwAwggEKAoIBAQCjsVsAf9Bn
;;; 4tArwMyDl6a3MRqeM2J+DzjpGiuygsYKM0y1xVnU7fB7QUz/XxBaN3aXiJ8GPGpY
;;; accLwgSjQja/GU+bMz5fZ70Sk43jLVF0UATXt4Bj36V/hxbBTRswkrMpqoz70C3g
;;; 1uNkrpsvVP95Fy2C3tHdM7iJEflFU5d3PKi+OflkNDN2E2XkYInQZcnoWgi/hHLo
;;; dZKvA3WZ5O94iZtk78ug/IumwGWi+ALQurFEiAQMQHCDqDNXAk2+v/Wl3ioSNpWV
;;; cT/riwp11IXopY+mCkOmZglcYnc7D3/ry2yeCJ2TLv++VJtWxLy6lsUGic3L8vHg
;;; d/kyCvqd7JidAgMBAAGjggGuMIIBqjAfBgNVHSMEGDAWgBQpkWD/ik366/mmarjP
;;; +eZLvUnOEjAdBgNVHQ4EFgQUi0Hw/1VLGAwOYI5Ztfk5kCJKhhQwDgYDVR0PAQH/
;;; BAQDAgeAMAwGA1UdEwEB/wQCMAAwEwYDVR0lBAwwCgYIKwYBBQUHAwMwEQYJYIZI
;;; AYb4QgEBBAQDAgQQMEYGA1UdIAQ/MD0wOwYMKwYBBAGyMQECAQMCMCswKQYIKwYB
;;; BQUHAgEWHWh0dHBzOi8vc2VjdXJlLmNvbW9kby5uZXQvQ1BTMEMGA1UdHwQ8MDow
;;; OKA2oDSGMmh0dHA6Ly9jcmwuY29tb2RvY2EuY29tL0NPTU9ET1JTQUNvZGVTaWdu
;;; aW5nQ0EuY3JsMHQGCCsGAQUFBwEBBGgwZjA+BggrBgEFBQcwAoYyaHR0cDovL2Ny
;;; dC5jb21vZG9jYS5jb20vQ09NT0RPUlNBQ29kZVNpZ25pbmdDQS5jcnQwJAYIKwYB
;;; BQUHMAGGGGh0dHA6Ly9vY3NwLmNvbW9kb2NhLmNvbTAfBgNVHREEGDAWgRRzdXBw
;;; b3J0QG1hbnVzb2Z0LmNvbTANBgkqhkiG9w0BAQsFAAOCAQEAE2rS0S3ucoM/0xNM
;;; C7isOCd+ltT6ExWNqS1Sk7+W8UO911nQtYpovxk/h8imcF83mXlSGK0Kd5AnSC+L
;;; g78HkK7spHJxhiJDZOBtDcj+AYMknGBAeT5f0uGZaQchp7R3bNtK9YTsgF+N5ffM
;;; toqrxe77h2FG024PRpEJ0VusrKOJWOStaG06aLHdoebIc9k5wzXn/EIJzyWAksJB
;;; ziHpKt9ymkofHPoO/Nu8mGfW9Wv9eCRMdzo51fjuhIoi8vuKpFJOjrNzcxxk+1lZ
;;; 8MftGtgs1WjlypcjN+QYERiZg8sElhf1Yrylt/BGlCSjoPx3MVI6aAA7oVfKTphf
;;; oLBLWjGCAbwwggG4AgEBMIGQMH0xCzAJBgNVBAYTAkdCMRswGQYDVQQIExJHcmVh
;;; dGVyIE1hbmNoZXN0ZXIxEDAOBgNVBAcTB1NhbGZvcmQxGjAYBgNVBAoTEUNPTU9E
;;; TyBDQSBMaW1pdGVkMSMwIQYDVQQDExpDT01PRE8gUlNBIENvZGUgU2lnbmluZyBD
;;; QQIPJa78jzkg549/okqzon3RMA0GCSqGSIb3DQEBCwUAMA0GCSqGSIb3DQEBAQUA
;;; BIIBAEbC2LnRQ5QwIlXug441F99B+s3/wJHsiyTU4shQSLEN6DUnD/oXhBo45rK3
;;; tVmQzc7vze4Pgoh0RvC5q7/fzPWKkKvLG9WmTT4kHtMXy4yeHgGxeLGuVsCgP+Lm
;;; 6zNLeBuuur800GLiLishqXPfOPrXtruuyzwFrNxT8GxOp/caGFQIYk0K6/taaE7p
;;; g4YwHkAF4Hhw2qShGlY95GsnMsvHuTV7PCJqigb0u1uKwM0ARBN/GevRaV5jz+OS
;;; gQjxDafroQst3c0SmUxeu5XfiMdB6iuLCg3+xutkEDTrmnHlUxH1q0T0rJX0lw+I
;;; 5eVpb34XaUSPj+R951egba4jZ7M=
;;; gwgbUGA1UdDjGBrQSBqjgAMQA7ADMA
;;; LwAyADcALwAyADAAMQA1AC8ANAAvADUAOAAvADEALwBOAGEAdABpAG8AbgBhAGwA
;;; IABJAG4AcwB0AGkAdAB1AHQAZQAgAG8AZgAgAFMAdABhAG4AZABhAHIAZABzACAA
;;; YQBuAGQAIABUAGUAYwBoAG4AbwBsAG8AZwB5ACAAKAB0AGkAbQBlAC0AYQAuAG4A
;;; aQBzAHQALgBnAG8AdgApAAAA
;;; ;;; -----END-SIGNATURE-----