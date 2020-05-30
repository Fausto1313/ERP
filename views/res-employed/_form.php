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
 
/*Al tener la relacion en el modelo nos es posible en ves de cargar el id el nombre directamente 
al registrar el nuevo empleado guardara el id */
$Scheduler= ResCompany::find()
->where(['partner_id'=>280])
->all();

//$Scheduler->id = 10;
 

$SchedulerList=ArrayHelper::map($Scheduler,'partner_id','name');
 

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
 

         
     </div>

    <div class="form-group">
        <?= Html::submitButton('Guardar', ['class' => 'btn btn-success']) ?>
    </div>

    <?php ActiveForm::end(); ?>

</div>

</div>
