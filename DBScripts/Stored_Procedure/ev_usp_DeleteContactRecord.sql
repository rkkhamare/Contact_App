IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ev_usp_DeleteContactRecord]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ev_usp_DeleteContactRecord] 
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ==============================================================    
-- Author		: Rajdeepsingh Khamare
-- Create date	: 11-Jun-2018
-- Description	: This procedure use to soft delete Contact record from system
-- Parameters	: @paramId - Contact primary key as ID.
-- Call			: EXEC [dbo].[ev_usp_DeleteContactRecord] 'id'    
-- =============================================================== 
-- ====================== CHANGE LOG =============================    
-- Author			: Rajdeepsingh K.Khamare		
-- Change date		: 12-Jun-2018
-- Change Details	: Added conditon for IsDeleted check
-- Parameters		: No change     
-- =============================================================== 
CREATE PROCEDURE [dbo].[ev_usp_DeleteContactRecord] 
(
	@paramId int
)
AS
BEGIN
  SET NOCOUNT ON

  /* Declaration Block */
  DECLARE @varErrorMessage nvarchar(4000)
  DECLARE @varErrorSeverity int
  DECLARE @varErrorState int

  BEGIN TRY
    UPDATE ev_tbl_Contacts
    SET IsDeleted = 1
    WHERE Id = @paramId

    SELECT
      1
  END TRY

  BEGIN CATCH
    SELECT
      0

    SELECT
      @varErrorMessage = 'Error : ' + HOST_NAME() + ' : ' + OBJECT_NAME(@@PROCID) + ' : ' + ERROR_MESSAGE(),
      @varErrorSeverity = ERROR_SEVERITY(),
      @varErrorState = ERROR_STATE();

    RAISERROR (
    @varErrorMessage
    ,-- Message text.
    @varErrorSeverity
    ,-- Severity.
    @varErrorState -- State.
    );
  END CATCH

  SET NOCOUNT OFF
END