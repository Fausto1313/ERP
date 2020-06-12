<?php

use yii\helpers\Html;
use yii\widgets\ActiveForm;

?>

<div class="sale-order-form">

    <?php $form = ActiveForm::begin([ 'enableClientValidation' => true,
    'options'                => [
       'id'      => 'dynamic-form'
        ]]

    ); ?>

<div class="modal-header">
<div class="row">
<div class="form-group col-md-6">

<?php
use yii\helpers\ArrayHelper;
use app\models\SaleOrder;
use app\models\ResUsers;
use app\models\ResPartner;
use app\models\ResCompany;
use app\models\CrmTeam;
 
/*Al tener la relacion en el modelo nos es posible en ves de cargar el id el nombre directamente 
al registrar el nuevo empleado guardara el id */
$Scheduler= ResUsers::find()
->all();
 
$SchedulerList=ArrayHelper::map($Scheduler,'id','login');

$Scheduler1= ResPartner::find()
->all();
 
$SchedulerList1=ArrayHelper::map($Scheduler1,'name','name');

$Scheduler2= ResCompany::find()
->all();
 
$SchedulerList2=ArrayHelper::map($Scheduler2,'name','name');

$Scheduler3= CrmTeam::find()
->all();
 
$SchedulerList3=ArrayHelper::map($Scheduler3,'name','name');
 
?>

</div>


    <!--<div class="form-group col-md-6">
          <?= $form->field($model, 'campaign_id')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Nombre del Cliente']) ?> 
    </div>

    <div class="form-group col-md-6">
          <?= $form->field($model, 'source_id')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Id Compañia']) ?> 
    </div>
       

    <div class="form-group col-md-6">
         <?= $form->field($model, 'medium_id')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Fecha de Creación']) ?> 
    </div>

    <div class="form-group col-md-6">
         <?= $form->field($model, 'message_main_attachment_id')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Nombre a mostrar']) ?> 
    </div>

    <div class="form-group col-md-6">
         <?= $form->field($model, 'access_token')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Fecha']) ?> 
    </div>-->

    <div class="form-group col-md-6">
         <?= $form->field($model, 'name')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Nombre de Presupuesto']) ?> 
    </div>

    <!--<div class="form-group col-md-6">
         <?= $form->field($model, 'origin')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Id Cliente']) ?> 
    </div>

    <div class="form-group col-md-6">
         <?= $form->field($model, 'client_order_ref')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'ref']) ?> 
    </div>

    <div class="form-group col-md-6">
         <?= $form->field($model, 'reference')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'lang']) ?> 
    </div>

    <div class="form-group col-md-6">
         <?= $form->field($model, 'state')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Estatus']) ?> 
    </div>-->

    <div class="form-group col-md-6">
          <?php $fecha = date('Y-m-d'); ?>
        <?= $form->field($model, 'date_order' )->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Fecha de Orden', 'type'=>'date', 'min'=> $fecha]) ?> 
    </div>

    <!--<div class="form-group col-md-6">
         <?= $form->field($model, 'validity_date')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Fecha validada']) ?> 
    </div>

    <div class="form-group col-md-6">
         <?= $form->field($model, 'require_signature')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'website']) ?> 
    </div>

    <div class="form-group col-md-6">
         <?= $form->field($model, 'require_payment')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'comment']) ?> 
    </div>

    <div class="form-group col-md-6">
         <?= $form->field($model, 'create_date')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Fecha de Creacion']) ?> 
    </div>-->

    <div class="form-group col-md-6">
         <?=$form->field($model, 'user_id')->dropDownList($SchedulerList,['prompt'=>'Seleccione el Email del usuario','style'=>'width:400px']);?> 
    </div>

    <div class="form-group col-md-6">
         <?= $form->field($model, 'partner_name')->dropDownList($SchedulerList1,['prompt'=>'Seleccione el cliente','style'=>'width:400px']);?> 
    </div>

    <div class="form-group col-md-6">
         <?= $form->field($model, 'partner_invoice_name')->dropDownList($SchedulerList1,['prompt'=>'Seleccione el socio de factura','style'=>'width:400px']);?> 
    </div>

    <div class="form-group col-md-6">
         <?= $form->field($model, 'partner_shipping_name')->dropDownList($SchedulerList1,['prompt'=>'Seleccione el socio de envio','style'=>'width:400px']);?> 
    </div> 

    <div class="form-group col-md-6">
         <?= $form->field($model, 'pricelist_id')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Id de lista de precios']) ?> 
    </div>

    <!--<div class="form-group col-md-6">
         <?= $form->field($model, 'analytic_account_id')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'zip']) ?> 
    </div>

    <div class="form-group col-md-6">
         <?= $form->field($model, 'invoice_status')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Ciudad']) ?> 
    </div>-->
     
    <div class="form-group col-md-6">
         <?= $form->field($model, 'note')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Nota']) ?> 
    </div>

    <!-- <div class="form-group col-md-6">
         <?= $form->field($model, 'amount_untaxed')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'partner_latitude']) ?> 
    </div>


    <div class="form-group col-md-6">
         <?= $form->field($model, 'amount_tax')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Calle 2']) ?> 
    </div>

    <div class="form-group col-md-6">
         <?= $form->field($model, 'amount_total')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'zip']) ?> 
    </div>

    <div class="form-group col-md-6">
         <?= $form->field($model, 'currency_rate')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Ciudad']) ?> 
    </div>
     
    <div class="form-group col-md-6">
         <?= $form->field($model, 'payment_term_id')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Nota']) ?> 
    </div>

     <div class="form-group col-md-6">
         <?= $form->field($model, 'fiscal_position_id')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'partner_latitude']) ?> 
    </div>-->
  

      <div class="form-group col-md-6">
         <?= $form->field($model, 'company_name')->dropDownList($SchedulerList2,['prompt'=>'Seleccione la compañia','style'=>'width:400px']);?> 
    </div>

   <div class="form-group col-md-6">
         <?= $form->field($model, 'team_name')->dropDownList($SchedulerList3,['prompt'=>'Seleccione el equipo de ventas','style'=>'width:400px']); ?> </div>

    <!--<div class="form-group col-md-6">
         <?= $form->field($model, 'signed_by')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Calle']) ?> 
    </div>

    <div class="form-group col-md-6">
         <?= $form->field($model, 'signed_on')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Calle 2']) ?> 
    </div>

    <div class="form-group col-md-6">
         <?= $form->field($model, 'commitment_date')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'zip']) ?> 
    </div>

    <div class="form-group col-md-6">
         <?= $form->field($model, 'create_uid')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Id de Usuario']) ?> 
    </div>
     
    <div class="form-group col-md-6">
         <?= $form->field($model, 'write_uid')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Nota']) ?> 
    </div>

     <div class="form-group col-md-6">
         <?= $form->field($model, 'write_date')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'partner_latitude']) ?> 
    </div>


    <div class="form-group col-md-6">
         <?= $form->field($model, 'sale_order_template_id')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Calle 2']) ?> 
    </div>

    <div class="form-group col-md-6">
         <?= $form->field($model, 'incoterm')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'zip']) ?> 
    </div>-->

    <div class="form-group col-md-6">
         <?= $form->field($model, 'picking_policy')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Politica de picking']) ?> 
    </div>
     
    <div class="form-group col-md-6">
         <?= $form->field($model, 'warehouse_id')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'ID de almacén']) ?> 
    </div>

     <!--<div class="form-group col-md-6">
         <?= $form->field($model, 'procurement_group_id')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'partner_latitude']) ?> 
    </div>


    <div class="form-group col-md-6">
         <?= $form->field($model, 'effective_date')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'zip']) ?> 
    </div>

    <div class="form-group col-md-6">
         <?= $form->field($model, 'opportunity_id')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Id de Oportunidad']) ?> 
    </div>
     
    <div class="form-group col-md-6">
         <?= $form->field($model, 'cart_recovery_email_sent')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Nota']) ?> 
    </div>

     <div class="form-group col-md-6">
         <?= $form->field($model, 'website_id')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'partner_latitude']) ?> 
    </div>

     <div class="form-group col-md-6">
         <?= $form->field($model, 'warning_stock')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Nota']) ?> 
    </div>

     <div class="form-group col-md-6">
         <?= $form->field($model, 'trial539')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'partner_latitude']) ?> 
    </div>-->
</div>

    <div class="form-group">
        <?= Html::submitButton('Guardar', ['class' => 'btn btn-success']) ?>
    </div>

    <?php ActiveForm::end(); ?>

</div>

</div>