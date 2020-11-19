
CREATE TRIGGER trig_INSERT_production_mngodr
AFTER INSERT ON production_mngodr
FOR EACH ROW
BEGIN
    --
    -- 원자재 및 부자재 수량 감소 부분
    --
    UPDATE manage_curmat ,
        (SELECT bom_no as mat_no, bom_count * NEW.mngodr_count as curmat_count 
        FROM info_bom 
        WHERE bom_parent_no=NEW.mat_no AND bom_no != NEW.mat_no) as temp
    SET manage_curmat.curmat_count = manage_curmat.curmat_count - temp.curmat_count
    WHERE manage_curmat.mat_no = temp.mat_no 
    AND (manage_curmat.ware_no=20000 OR manage_curmat.ware_no=20001);

    --
    -- 제품 수량 증가 부분
    --
    INSERT INTO manage_curmat(ware_no, mat_no, curmat_count) 
    VALUES(NEW.ware_no, NEW.mat_no, NEW.mngodr_count)
    ON DUPLICATE KEY UPDATE curmat_count = curmat_count + NEW.mngodr_count;    
END


CREATE TRIGGER trig_INSERT_real_stock_taking
AFTER INSERT ON manage_realstocktake
FOR EACH ROW
BEGIN
    IF NEW.stocktake_type = '추가' THEN 
        BEGIN
            UPDATE manage_curmat SET curmat_count = curmat_count + NEW.stocktake_changecount 
            WHERE ware_no = NEW.ware_no AND mat_no = NEW.mat_no;
        END; 
    END IF;
    
    IF NEW.stocktake_type = '차감' THEN 
        BEGIN
            UPDATE manage_curmat SET curmat_count = curmat_count - NEW.stocktake_changecount 
            WHERE ware_no = NEW.ware_no AND mat_no = NEW.mat_no;
        END; 
    END IF;
END



CREATE TRIGGER boxing_insert 
AFTER INSERT ON production_prodrecod 
FOR EACH ROW
BEGIN
    declare _total int default 0;
    set _total = (SELECT curmat_count FROM manage_curmat WHERE ware_no = NEW.ware_no AND mat_no in 
                                                                                        (SELECT mat_no FROM production_mngodr WHERE mngodr_no = NEW.mngodr_no)) 
                + NEW.prodrecod_good;
    UPDATE manage_curmat SET curmat_count = _total WHERE ware_no = NEW.ware_no AND mat_no in 
                                                                                    (SELECT mat_no FROM production_mngodr WHERE mngodr_no = NEW.mngodr_no);

    UPDATE manage_curmat SET curmat_count = (SELECT curmat_count FROM manage_curmat WHERE ware_no in 
                                                                                        (SELECT ware_no FROM production_mngodr WHERE mngodr_no = NEW.mngodr_no) 
                                                                                    AND mat_no in 
                                                                                        (SELECT mat_no FROM production_mngodr WHERE mngodr_no = NEW.mngodr_no)) 
                                            - (SELECT mngodr_count FROM production_mngodr WHERE mngodr_no = NEW.mngodr_no) 
    WHERE ware_no in 
            (SELECT ware_no FROM production_mngodr WHERE mngodr_no = NEW.mngodr_no) 
    AND mat_no in 
            (SELECT mat_no FROM production_mngodr WHERE mngodr_no = NEW.mngodr_no);

	IF NEW.ware_no = 20003 AND _total > 20
	THEN
		BEGIN
			UPDATE manage_curmat SET curmat_count = curmat_count + _total div 20 
            WHERE ware_no = 20004 AND mat_no in 
                                  (SELECT bom_parent_no FROM info_bom WHERE bom_no in 
                                                                            (SELECT mat_no FROM production_mngodr WHERE mngodr_no = NEW.mngodr_no) 
                                    AND bom_count = 20);

			UPDATE manage_curmat SET curmat_count = (_total % 20) 
            WHERE ware_no = 20003 AND mat_no in 
                                    (SELECT mat_no FROM production_mngodr WHERE mngodr_no = NEW.mngodr_no);
		END;
	END IF;
END