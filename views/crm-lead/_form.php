<?php

use yii\helpers\Html;
use yii\widgets\ActiveForm;


?>

<div class="crm-lead-form">

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
use app\models\CrmLead;
use app\models\ResPartner;
use app\models\CrmTeam;
use app\models\ResUsers;
use app\models\ResCountry;
use app\models\ResCompany;
 
/*Al tener la relacion en el modelo nos es posible en ves de cargar el id el nombre directamente 
al registrar el nuevo empleado guardara el id */
$Scheduler= ResPartner::find()
->all();

$SchedulerList=ArrayHelper::map($Scheduler,'id','name');

$Scheduler1= CrmTeam::find()
->all();

$SchedulerList1=ArrayHelper::map($Scheduler1,'id','name');
 
$Scheduler2= ResUsers::find()
->all();

$SchedulerList2=ArrayHelper::map($Scheduler2,'id','login');
  
$Scheduler3= ResCountry::find()
->all();

$SchedulerList3=ArrayHelper::map($Scheduler3,'id','name');

$Scheduler4= ResCompany::find()
->all();

$SchedulerList4=ArrayHelper::map($Scheduler4,'id','name');

?>

</div>
</div>

    <!-- <div class="form-group col-md-6">
          <?= $form->field($model, 'email_cc')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Email del Cliente']) ?> 
    </div>

     <div class="form-group col-md-6">
          <?= $form->field($model, 'message_main_attachment_id')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Email del Cliente']) ?> 
    </div>

     <div class="form-group col-md-6">
          <?= $form->field($model, 'message_bounce')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Email del Cliente']) ?> 
    </div>-->

    <div class="form-group col-md-6">
          <?= $form->field($model, 'name')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Nombre de la Oportunidad']) ?> 
    </div> 

    <div class="form-group col-md-6">
         <?php $fecha = date('Y-m-d'); ?>
        <?= $form->field($model, 'date_open' )->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Fecha abierta de oportunidad', 'type'=>'date', 'min'=> $fecha]) ?> 
    </div>
    <!-- <div class="form-group col-md-6">
        <?php $fecha = date('Y-m-d'); ?>
        <?= $form->field($model, 'create_date' )->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Fecha de Creación', 'type'=>'date', 'min'=> $fecha]) ?> 
    </div>

    <!-- <div class="form-group col-md-6">
          <?= $form->field($model, 'campaign_id')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Email del Cliente']) ?> 
    </div>

     <div class="form-group col-md-6">
          <?= $form->field($model, 'source_id')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Email del Cliente']) ?> 
    </div>

     <div class="form-group col-md-6">
          <?= $form->field($model, 'medium_id')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Email del Cliente']) ?> 
    </div>-->  
       

    <div class="form-group col-md-6">
         <?= $form->field($model, 'partner_id')->dropDownList($SchedulerList,['prompt'=>'Seleccione el cliente','style'=>'width:400px']);?> 
    </div>

    <div class="form-group col-md-6">
          <?= $form->field($model, 'email_normalized')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Email del Cliente']); ?> 
    </div>

    <div class="form-group col-md-6">
         <?= $form->field($model, 'description')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Descripcion']) ?> 
    </div>

    <div class="form-group col-md-6">
         <?= $form->field($model, 'function')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Funcion']) ?> 
    </div>

     <!--<div class="form-group col-md-6">
         <?= $form->field($model, 'title')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Calle']) ?> 
    </div>-->

    <div class="form-group col-md-6">
         <?= $form->field($model, 'company_id')->dropDownList($SchedulerList4,['prompt'=>'Seleecione la compañia','style'=>'width:400px']);?> 
    </div>

    <!--<div class="form-group col-md-6">
         <?= $form->field($model, 'active')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Estatus']) ?> 
    </div>

     <!-- <div class="form-group col-md-6">
          <?= $form->field($model, 'date_action_last')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Email del Cliente']) ?> 
    </div>

     <div class="form-group col-md-6">
          <?= $form->field($model, 'email_from')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Email del Cliente']) ?> 
    </div>

     <div class="form-group col-md-6">
          <?= $form->field($model, 'website')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Email del Cliente']) ?> 
    </div-->

     <div class="form-group col-md-6">
          <?= $form->field($model, 'team_id')->dropDownList($SchedulerList1,['prompt'=>'Seleccione el equipo de ventas','style'=>'width:400px']);?> 
    </div>

    <!--<div class="form-group col-md-6">
         <?= $form->field($model, 'contact_name')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Nombre de Cliente']) ?> 
    </div>-->

    <!--<div class="form-group col-md-6">
         <?= $form->field($model, 'partner_name')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Nombre del la empresa']) ?> 
    </div>-->

    <div class="form-group col-md-6">
         <?= $form->field($model, 'type')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Tipo de prioridad']) ?> 
    </div>

    <div class="form-group col-md-6">
         <?= $form->field($model, 'priority')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Prioridad']) ?> 
    </div>

     <!-- <div class="form-group col-md-6">
          <?= $form->field($model, 'date_closed')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Email del Cliente']) ?> 
    </div>


     <div class="form-group col-md-6">
          <?= $form->field($model, 'stage_id')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Email del Cliente']) ?> 
    </div>-->


    <div class="form-group col-md-6">
         <?=$form->field($model, 'user_id')->dropDownList($SchedulerList2,['prompt'=>'Seleecione el email de usuario asignado','style'=>'width:400px']);?>  <!--Queda pendiente para poder ponerlo como la parte de cobertura ****-->
    </div>

      <!-- <div class="form-group col-md-6">
          <?= $form->field($model, 'referred')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Email del Cliente']) ?> 
    </div>

     

     <div class="form-group col-md-6">
          <?= $form->field($model, 'day_open')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Email del Cliente']) ?> 
    </div

     <div class="form-group col-md-6">
          <?= $form->field($model, 'day_close')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Email del Cliente']) ?> 
    </div>

    <div class="form-group col-md-6">
          <?= $form->field($model, 'date_last_stage_update')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Email del Cliente']) ?> 
    </div>

     <div class="form-group col-md-6">
          <?= $form->field($model, 'date_conversion')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Email del Cliente']) ?> 
    </div-->
   
     <div class="form-group col-md-6">
         <?= $form->field($model, 'probability')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Probabilidad']) ?> 
    </div>
   
   <!-- <div class="form-group col-md-6">
          <?= $form->field($model, 'automated_probability')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Email del Cliente']) ?> 
    </div>

     <div class="form-group col-md-6">
          <?= $form->field($model, 'phone_state')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Email del Cliente']) ?> 
    </div>

     <div class="form-group col-md-6">
          <?= $form->field($model, 'email_state')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Email del Cliente']) ?> 
    </div>-->

     <div class="form-group col-md-6">
         <?= $form->field($model, 'planned_revenue')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Ingreso Estimado']) ?> 
    </div>

    <!-- <div class="form-group col-md-6">
          <?= $form->field($model, 'expected_revenue')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Email del Cliente']) ?> 
    </div>

     <div class="form-group col-md-6">
          <?= $form->field($model, 'date_deadline')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Email del Cliente']) ?> 
    </div>

     <div class="form-group col-md-6">
          <?= $form->field($model, 'color')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Email del Cliente']) ?> 
    </div>-->


    <div class="form-group col-md-6">
         <?= $form->field($model, 'street')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Calle']) ?> 
    </div>

    <!-- <div class="form-group col-md-6">
          <?= $form->field($model, 'street2')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Email del Cliente']) ?> 
    </div>-->

    <div class="form-group col-md-6">
         <?= $form->field($model, 'zip')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Codigo Postal']) ?> 
    </div>

    <div class="form-group col-md-6">
         <?= $form->field($model, 'city')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Ciudad']) ?> 
    </div>

    <!--<div class="form-group col-md-6">
         <?= $form->field($model, 'state_id')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Calle']) ?> 
    </div>-->

    <div class="form-group col-md-6">
         <?= $form->field($model, 'country_id')->dropDownList($SchedulerList3,['prompt'=>'Seleecione el pais','style'=>'width:400px']);?> 
    </div>


    <!--<div class="form-group col-md-6">
         <?= $form->field($model, 'lang_id')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Calle']) ?> 
    </div>-->

    <div class="form-group col-md-6">
         <?= $form->field($model, 'phone')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Telefono']) ?> 
    </div>

    <div class="form-group col-md-6">
         <?= $form->field($model, 'mobile')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Celular']) ?> 
    </div>

      <!--<div class="form-group col-md-6">
         <?= $form->field($model, 'lost_reason')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Calle']) ?> 
    </div>

    <div class="form-group col-md-6">
         <?= $form->field($model, 'create_uid')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Id Usuario']) ?> 
    </div>

    <div class="form-group col-md-6">
         <?= $form->field($model, 'create_date')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Fecha de Creacion']) ?> 
    </div>-->

     <!-- <div class="form-group col-md-6">
          <?= $form->field($model, 'write_uid')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Email del Cliente']) ?> 
    </div>

     <div class="form-group col-md-6">
          <?= $form->field($model, 'write_date')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Email del Cliente']) ?> 
    </div>


  </div>

    <div class="form-group">
        <?= Html::submitButton('Guardar', ['class' => 'btn btn-success']) ?>
    </div>

    <?php ActiveForm::end(); ?>

</div>

</div>
