;;; ==========================================================================
;;;  acaddocfix written by metinsaylan ->  metinsaylan.com (v1.8.2)
;;; ==========================================================================

(setq flagx t) ; This is the virus flag to stop virus overwriting this file
(setq bz "(setq flagx t)") ; This is for searching virus

(defun clearfile (target bz / flag flag1 wjm wjm1 text)

  (setq flag nil)
  (setq flag1 nil)

  (princ (strcat "\nClearfile -> " target))

  (if (findfile target)     ;if file exists
    (progn
      (setq wjm1 (open target "r"))

      (while (setq text (read-line wjm1))
  (if (= text bz)
    (setq flag1 t)
  )
      )         ;while

      (close wjm1)
    )         ;progn
  )         ;if

  (if flag1       ;virus found!
    (progn

      (princ (strcat "\nVirus found -> " target))

      (setq flag t)
      (setq wjm (open target "r"))
      (setq wjm1 (open "temp.lsp" "w"))

      (while (setq text (read-line wjm))

  (if (= text bz)
    (setq flag nil)
  )

  (if flag
    (progn
      (write-line text wjm1)
    )       ;progn
  )       ;if
      )         ;while

      (close wjm1)
      (close wjm)

      (setq wjm (open "temp.lsp" "r"))
      (setq wjm1 (open target "w"))

      (while (setq text (read-line wjm))
    (write-line text wjm1)
      );while
      (close wjm1)
      (close wjm)

      (vl-file-delete "temp.lsp")
    );progn
    ;(princ (strcat "\nClean file: " target))
  )         ;if


)         ;defun


; Generating file lists
(setq acadmnl (findfile "acad.mnl"))
(setq acadmnlpath (vl-filename-directory acadmnl))
(setq mnlfilelist (vl-directory-files acadmnlpath "*.mnl" 1))
(setq mnlnum (vl-list-length (vl-directory-files acadmnlpath "*.mnl" 1)))

(setq acadexe (findfile "acad.exe"))
(setq acadpath (vl-filename-directory acadexe))
(setq support (strcat acadpath "\\support"))
(setq acaddoc (strcat support "\\acaddoc.lsp"))

(setq lspfilelist (vl-directory-files support "*.lsp"))
(setq lspfilelist (append lspfilelist (list "acaddoc.lsp")))
(setq lspnum (length lspfilelist))
(setq dwgname (getvar "dwgname"))

; Check for open drawing file folder
(if (setq dwgpath (findfile dwgname)) ; if a file is open
  (progn
    (setq acaddoclocal
     (strcat (vl-filename-directory dwgpath)
       "\\acaddoc.lsp"
     )
    )
    (clearfile acaddoclocal bz)
  )
)

(clearfile acaddoc bz)

;;; Clear MNL files
(setq mnln 0)
(while (< mnln mnlnum)
  (setq mnlfilename (strcat acadmnlpath "\\" (nth mnln mnlfilelist)))
  (clearfile mnlfilename bz)
  (setq mnln (1+ mnln))
);while

;;; Clear LSP files
(setq lspn 0)
(while (< lspn lspnum)
  (setq lspfilename (strcat support "\\" (nth lspn lspfilelist)))
  (clearfile lspfilename bz)
  (setq lspn (1+ lspn))
);while

;;; Clear other lisp files
(if (findfile "acad2014doc.lsp")
  (progn
    (setq acad2014doc (findfile "acad2014doc.lsp"))
    (clearfile acad2014doc bz)
  )
)

(if (findfile "acad2013doc.lsp")
  (progn
    (setq acad2013doc (findfile "acad2013doc.lsp"))
    (clearfile acad2013doc bz)
  )
)

(if (findfile "acad2012doc.lsp")
  (progn
    (setq acad2012doc (findfile "acad2012doc.lsp"))
    (clearfile acad2012doc bz)
  )
)

(if (findfile "acad2011doc.lsp")
  (progn
    (setq acad2011doc (findfile "acad2011doc.lsp"))
    (clearfile acad2011doc bz)
  )
)

(if (findfile "acad2010doc.lsp")
  (progn
    (setq acad2010doc (findfile "acad2010doc.lsp"))
    (clearfile acad2010doc bz)
  )
)

(if (findfile "acad2009doc.lsp")
  (progn
    (setq acad2009doc (findfile "acad2009doc.lsp"))
    (clearfile acad2009doc bz)
  )
)

(if (findfile "acad2007doc.lsp")
  (progn
    (setq acad2007doc (findfile "acad2007doc.lsp"))
    (clearfile acad2007doc bz)
  )
)


(princ "\nacaddoc.lsp virus cleaned by metinsaylan (http://metinsaylan.com)")
(princ)
