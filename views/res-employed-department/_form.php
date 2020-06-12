<?php

use yii\helpers\Html;
use yii\widgets\ActiveForm;

?>

<div class="res-employed-department-form">

    <?php $form = ActiveForm::begin([ 'enableClientValidation' => true,
    'options' => [
       'id' => 'dynamic-form'
        ]]
    ); ?>

<div class="modal-header">
<div class="row">
<div class="form-group col-md-6">
    <?php
    use yii\helpers\ArrayHelper;
    use app\models\ResEmployedDepartment;
    use app\models\ResCompany;
     
    /*Al tener la relacion en el modelo nos es posible en ves de cargar el id el nombre directamente 
    al registrar el nuevo empleado guardara el id */
    $Scheduler= ResCompany::find()
    ->all();
    $SchedulerList=ArrayHelper::map($Scheduler,'id','name');
     
     
    ?>

</div>
</div>
     <div class="form-group col-md-6">
          <?= $form->field($model, 'name')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Nombre del Departamento']) ?> 
    </div>       

    <div class="form-group col-md-6">
         <?= $form->field($model, 'complete_name')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Nombre completo']) ?> 
    </div>

    <div class="form-group col-md-6">
         <?= $form->field($model, 'active')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Estatus']) ?> 
    </div>

    <div class="form-group col-md-6">
         <?= $form->field($model, 'company_id')->dropDownList($SchedulerList,['prompt'=>'Seleccione una compañia', 'style'=>'width:400px']); ?> 
    </div>

    <!--<div class="form-group col-md-6">
         <?= $form->field($model, 'parent_id')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Cliente']) ?>  <!-- Es el cliente al que partenece (su padre)
    </div>-->

    <!--<div class="form-group col-md-6">
         <?= $form->field($model, 'manager_id')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Lider']) ?> 
    </div>-->

    <div class="form-group col-md-6">
         <?= $form->field($model, 'note')->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Nota']) ?> 
    </div>

    <div class="form-group col-md-6">
        <?php $fecha = date('Y-m-d'); ?>
        <?= $form->field($model, 'create_date' )->textInput(['maxlength' => true,'style'=>'width:400px','placeholder'=>'Fecha de Creación', 'type'=>'date', 'min'=> $fecha]) ?> 
    </div>
    
</div>

    <div class="form-group">
        <?= Html::submitButton('Guardar', ['class' => 'btn btn-success']) ?>
    </div>

    <?php ActiveForm::end(); ?>

</div>

</div>