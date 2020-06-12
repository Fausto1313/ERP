<?php

use yii\helpers\Html;
use yii\widgets\ActiveForm;

?>

<div class="res-employed-form">

<?php $form = ActiveForm::begin([ 'enableClientValidation' => true,
    'options'                => [
       'id'      => 'dynamic-form'
        ]]);
?>

<div class="modal-header">
<div class="row">
<div class="form-group col-md-6">

<?php
use yii\helpers\ArrayHelper;
use app\models\ResEmployed;
use app\models\ResCompany;
use app\models\ResCountry;
use app\models\ResEmployedDepartment;
 
/*Al tener la relacion en el modelo nos es posible en ves de cargar el id el nombre directamente 
al registrar el nuevo empleado guardara el id */
$Scheduler= ResCompany::find()
->all();
$SchedulerList=ArrayHelper::map($Scheduler,'name','name');

$Scheduler1= ResCountry::find()
->all();
$SchedulerList1=ArrayHelper::map($Scheduler1,'name','name');

$Scheduler2= ResEmployedDepartment::find()
->all();
$SchedulerList2=ArrayHelper::map($Scheduler2,'name','name');
 

echo $form->field($model, 'Id_Comp')->dropDownList($SchedulerList,['prompt'=>'Seleccione una compañia','style'=>'width:400px']);
 
?>

</div>
    <div class="form-group col-md-6">
      <?= $form->field($model, 'N_Empleado')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Nombre del Empleado']) ?> 
    </div>
   

    <div class="form-group col-md-6">
     <?= $form->field($model, 'E_Apellidos')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Apellidos']) ?> 
    </div>

    <div class="form-group col-md-6">
     <?= $form->field($model, 'E_Nomina')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Numero de Nomina']) ?> 
    </div>


    <div class="form-group col-md-6">
         <?= $form->field($model, 'active')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Activo/Inactivo']) ?> 
    </div>

    <div class="form-group col-md-6">
         <?= $form->field($model, 'gender')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Femenino/Masculino']) ?> 
    </div>

    <div class="form-group col-md-6">
         <?= $form->field($model, 'marital')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Estado civil']) ?> 
    </div>

    <div class="form-group col-md-6">
        <?php $fecha = date('Y-m-d'); ?>
        <?= $form->field($model, 'birthday' )->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Fecha de Cumpleaños', 'type'=>'date']) ?> 
    </div>

    <div class="form-group col-md-6">
         <?= $form->field($model, 'department_id')->dropDownList($SchedulerList2,['prompt'=>'Seleccione un departamento', 'style'=>'width:400px']); ?> 
    </div>

    <div class="form-group col-md-6">
         <?= $form->field($model, 'street')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Calle']) ?> 
    </div>

    <div class="form-group col-md-6">
         <?= $form->field($model, 'codigo_postal')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Codigo Postal']) ?> 
    </div>

    <div class="form-group col-md-6">
         <?= $form->field($model, 'ciudad')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Ciudad']) ?> 
    </div>

     <div class="form-group col-md-6">
         <?= $form->field($model, 'country_id')->dropDownList($SchedulerList1,['prompt'=>'Seleccione un pais', 'style'=>'width:400px']); ?> 
    </div>

    <div class="form-group col-md-6">
         <?= $form->field($model, 'work_phone')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Telefono de oficina']) ?> 
    </div>

    <div class="form-group col-md-6">
         <?= $form->field($model, 'mobile_phone')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Telefono Personal']) ?> 
    </div>

    <div class="form-group col-md-6">
         <?= $form->field($model, 'work_email')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Email de Trabajo']) ?> 
    </div>

    <div class="form-group col-md-6">
         <?= $form->field($model, 'work_location')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Lugar de trabajo']) ?> 
    </div>

    <div class="form-group col-md-6">
        <?php $fecha = date('Y-m-d'); ?>
        <?= $form->field($model, 'F_Creacion' )->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Fecha de Creación', 'type'=>'date']) ?> 
    </div>
         
</div>

    <div class="form-group">
        <?= Html::submitButton('Guardar', ['class' => 'btn btn-success']) ?>
    </div>

    <?php ActiveForm::end(); ?>

</div>

</div>
